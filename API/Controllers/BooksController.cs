using BLL;
using BLL.Interfaces;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly ILibrairiService _librairiService = BLLExtension.GetLibrariService();
        #region Get
        #region Get All
        [HttpGet]
        [Route("")]
        public IActionResult GetBooks()
        {
            return Ok(_librairiService.GetAllBooks());
        }
        #endregion
        #region Get by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetBookById(Guid? id)
        {
            if (id is null)
            {
                BadRequest("L'id doit être supérieur à 0");
            }
            try
            {
                //BLL
                Book bookById = _librairiService.GetBookById(id);
                //Retour BLL => DTO response
                var reponse = new GetBookByIdResponse();
                return Ok(reponse);
            }
            catch (NotFoundException ex)
            {
                return NotFound($"Le livre {id.Value} est introuvable");
            }
        }
        #endregion
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] CreateBookDTORequest createBookDTORequest)
        {
            // DTO => domaine metier
            Book newBook = new Book()
            {
                Title = createBookDTORequest.Title,
                Author = createBookDTORequest.Author,
                Description = createBookDTORequest.Description,
            };

            //BLL
            var book = _librairiService.CreateBook(newBook);

            //Retour BLL => DTO response
            var response = new CreateBookDTOResponse()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };
            return Ok(response);
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ModifyBook([FromRoute] Guid id, [FromBody] UpdateBookDTORequest updateBookDTORequest)
        {
            if (id != updateBookDTORequest.Id)
            {
                return BadRequest();
            }
            else
            {
                //BLL
                Book bookModified = _librairiService.UpdateBook(id);

                if (bookModified != null)
                {
                    //Retour BLL => DTO response
                    var reponse = new UpdateBookDTOResponse()
                    {
                        Id = updateBookDTORequest.Id,
                        Title = updateBookDTORequest.Title,
                        Author = updateBookDTORequest.Author,
                        Description = updateBookDTORequest.Description,
                    };

                    return Ok(reponse);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook([FromRoute] Guid? id)
        {
            if (id is null)
            {
                BadRequest("L'id doit être supérieur à 0");
            }

            if (_librairiService.DeleteBook(id.Value))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
    }
}

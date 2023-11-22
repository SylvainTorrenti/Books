using BLL;
using BLL.Interfaces;
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

        public IActionResult GetBookById(int id)
        {
            if (id<0)
            {
                BadRequest("L'id doit être supérieur à 0");
            }
            try
            {
                return Ok(_librairiService.GetBookById(id));
            }
            catch (NotFoundException ex) 
            { 
                return NotFound($"Le livre {id} est introuvable");
            }
        }
        #endregion
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = Book.Compteur;

            Book.books.Add(book);

            if (Book.books.Exists(b => book.Id == b.Id))
            {
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ModifyBook([FromRoute] int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            else
            {
                Book bookModified = book;
                if (bookModified != null)
                {
                    return Ok(bookModified);
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
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = Book.books.Find(b => b.Id == id);
            if (id == book.Id)
            {
                Book.books.Remove(book);
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

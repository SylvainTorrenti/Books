using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        #region Get
        #region Get All
        [HttpGet]
        [Route("")]
        public IActionResult GetBooks()
        {
            return Ok(Book.books);
        }
        #endregion
        #region Get by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookById(int id)
        {
            var book = Book.books.Find(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        #endregion
        #endregion

        #region Post
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = Book.Compteur;

            Book.books.Add(book);

            if (Book.books.Exists(b => book.Id == b.Id))
            {
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, null);
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = Book.books.Find(b => b.Id == id);
            if (id == book.Id)
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

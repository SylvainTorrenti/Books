using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetBooks()
        {
            return Ok(Book.books);
        }

        [Route("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = Book.books.Find(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = Book.Compteur;

            Book.books.Add(book);

            if (Book.books.Exists(b => book.Id == b.Id)) 
            {
               return CreatedAtAction(nameof(GetBookById), new { id = book.Id}, null);
            }
            else
            {
                return BadRequest();
            }
        }



    }
}

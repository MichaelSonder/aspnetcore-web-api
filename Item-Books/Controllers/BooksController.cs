using Item_Books.Data.Models;
using Item_Books.Data.Services;
using Item_Books.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Item_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public async Task<ActionResult> AddBook([FromBody] BookVM book)
        {
            await _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var allBooks = await _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _booksService.GetBookById(id);

            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]
        public async Task<ActionResult> UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = await _booksService.UpdateBookById(id, book);

            if (updatedBook == null)
            {
                return NotFound(new { message = "Book not found" });
            }

            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public async Task<ActionResult> DeleteBookById(int id)
        {
            await _booksService.DeleteBookById(id);
            return Ok();
        }


    }
}

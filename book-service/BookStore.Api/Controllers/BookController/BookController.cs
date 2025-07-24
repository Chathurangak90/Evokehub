using BookStore.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.BookController
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBook _iBook;

        public BookController(IBook iBook)
        {
            _iBook = iBook;
        }

        /// Retrieves all available books from different stores
        [HttpGet("loadallbooks")]
        public async Task<IActionResult> GetAllBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var books = await _iBook.GetAllBooks(pageNumber, pageSize);
            return Ok(books);
        }
    }
}

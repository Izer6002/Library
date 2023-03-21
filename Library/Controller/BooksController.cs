using Library.Entities;
using Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            var booksList=_libraryService.GetAllBooks();
            return booksList;
        }

        [HttpGet("GetBook")]
        public Book GetBook(int id)
        {
            var bookById=_libraryService.GetBook(id);
            return bookById;
        }

        [HttpPost("AddBook")]
        public void AddBook(Book book)
        {
            _libraryService.AddBook(book);
        }

        [HttpPut("UpdateBook")]
        public void UpdateBook(Book book)
        {
            _libraryService.UpdateBook(book);
        }

        [HttpDelete("DeleteBook")]
        public void DeleteBook(int id)
        {
            _libraryService.DeleteBook(id);
        }

        [HttpGet("BorrowBook")]
        public void BorrowBook(int id, User user)
        {
            _libraryService.BorrowBook(id, user);
        }

        [HttpGet("ReturnBook")]
        public void ReturnBook(int id)
        {
            _libraryService.ReturnBook(id);
        }

    }
}

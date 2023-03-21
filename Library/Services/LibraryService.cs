using Library.DataBase.Context;
using Library.Entities;
using Library.Interfaces;

namespace Library.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDBContext _context;
        public LibraryService(LibraryDBContext context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            book.Id = _context.BookList.Count<Book>() + 1;
            _context.BookList.Add(book);
        }

        public void BorrowBook(int id, User user)
        {
            var book = GetBook(id);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                _context.UserList.Add(user);
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book != null)
            {
                _context.BookList.Remove(book);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.BookList;
        }

        public Book GetBook(int id)
        {
            return _context.BookList.FirstOrDefault(b => b.Id == id);
        }

        public void ReturnBook(int id)
        {
            var book = GetBook(id);
            if (book != null)
            {
                book.IsAvailable = true;
            }
        }

        public void UpdateBook(Book book)
        {
            var oldBook = GetBook(book.Id);
            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Author= book.Author;
                oldBook.PublicationYear = book.PublicationYear;
                oldBook.IsAvailable = book.IsAvailable;
            }
        }

        
    }
}

using Library.Entities;

namespace Library.Interfaces
{
    public interface ILibraryService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        void BorrowBook(int id, User user);
        void ReturnBook(int id);
    }
}

using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataBase.Context
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> BookList { get; set; }
        public DbSet<User> UserList { get; set; }
    }
}

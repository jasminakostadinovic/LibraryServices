using System.Data.Entity;

namespace LibraryServices.Data.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext")
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}

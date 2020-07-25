using System.Data.Entity;

namespace LibraryServices.Data.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext")
        {
            Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Cost> Cost { get; set; }
    }
}

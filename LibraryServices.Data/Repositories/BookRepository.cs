using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> books = new List<Book>()
        {
            new Book(){Id = 1, Title = "The girl on the train", Author = "Hawkins, Paula", PublicationYear = 2015, CallNumber =  "F HAWKI"}
        };

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }
    }
}

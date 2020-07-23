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

        public bool Remove(int id)
        {
            var boorToRemove = GetBook(id);
            if (boorToRemove == null)
                return false;
            books.Remove(boorToRemove);
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            var bookToUpdate = GetBook(id);
            if (bookToUpdate == null)
                return books;

            bookToUpdate.Author = book.Author;
            bookToUpdate.CallNumber = book.CallNumber;
            bookToUpdate.IsAvailable = book.IsAvailable;
            bookToUpdate.PublicationYear = book.PublicationYear;
            bookToUpdate.Title = book.Title;

            return books;
        }
    }
}

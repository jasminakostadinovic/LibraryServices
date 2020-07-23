using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        private LibraryContext db = new LibraryContext();
        public bool AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(b => b.Id == id);
        }

        public bool Remove(int id)
        {
            var boorToRemove = GetBook(id);
            if (boorToRemove == null)
                return false;
            db.Books.Remove(boorToRemove);
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            var bookToUpdate = GetBook(id);
            if (bookToUpdate == null)
                return db.Books.ToList();

            bookToUpdate.Author = book.Author;
            bookToUpdate.CallNumber = book.CallNumber;
            bookToUpdate.IsAvailable = book.IsAvailable;
            bookToUpdate.PublicationYear = book.PublicationYear;
            bookToUpdate.Title = book.Title;

            return db.Books.ToList();
        }
    }
}

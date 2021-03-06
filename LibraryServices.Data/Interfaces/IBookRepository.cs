﻿using LibraryServices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);
        bool AddNewBook(Book book);
        bool Remove(int id);
        List<Book> UpdateBook(int id, Book book);
        List<Book> GetBookByAuthor(string name);
        string GetAuthorById(int id);
        Book GetBookByAuthorAndYear(string author, int year);
        Book AddCost(int id, Cost cost);
    }
}

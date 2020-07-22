﻿using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using LibraryServices.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace LibraryServices.Controllers
{
    public class BooksController : ApiController
    {
        //private IBookRepository books = new BookRepository();
        private IBookRepository books;
        public BooksController(IBookRepository books)
        {
            this.books = books;
        }

        // GET api/Books
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        // GET api/Books/5
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        //POST
        public IHttpActionResult PostBook(Book book)
        {
            var result = books.AddNewBook(book);
            if (result == true)
                return Ok(book);
            return BadRequest();
        }

    }
}

using LibraryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryServices.Controllers
{
    public class BooksController : ApiController
    {
        public List<Book> books = new List<Book>()
        {
            new Book(){Id = 1, Title = "The girl on the train", Author = "Hawkins, Paula", PublicationYear = 2015, CallNumber =  "F HAWKI"}
        };

        // GET api/Books
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

    }
}

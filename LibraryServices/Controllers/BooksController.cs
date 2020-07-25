using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using LibraryServices.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryServices.Controllers
{
    [EnableCors(origins: "https://localhost:44363", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        //private IBookRepository books = new BookRepository();
        private IBookRepository books;
        public BooksController(IBookRepository books)
        {
            this.books = books;
        }

        // GET api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        // GET api/Books/5
        [HttpGet]
        [Route("api/books/id/{id}")]
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // GET 
        [HttpGet]
        [Route("api/books/author/{id}")]
        public IHttpActionResult GetAuthorById(int id)
        {
            var authorName = books.GetAuthorById(id);
            if (authorName == null)
                return NotFound();
            return Ok(authorName);
        }

        // GET 
        [HttpGet]
        [Route("api/books/author/{author}/year/{year}")]
        public IHttpActionResult GetBookByAuthorAndYear(string author, int year)
        {
            var book = books.GetBookByAuthorAndYear(author, year);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        // GET 
        [HttpGet]
        [Route("api/books/{name}")]
        public IHttpActionResult GetBooksByAuthor(string name)
        {
            var bookList = books.GetBookByAuthor(name);
            if (bookList == null)
                return NotFound();
            return Ok(bookList);
        }

        //POST
        [HttpPost]
        public IHttpActionResult PostBook(Book book)
        {
            var result = books.AddNewBook(book);
            if (result == true)
                return Ok(book);
            return BadRequest();
        }

        //DELETE
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (books.Remove(id))
                return Ok(books.GetAllBooks());
            return NotFound();
        }

        //UPDATE
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            var updatedBook = books.UpdateBook(id, book);
            if (updatedBook != null)
                return Ok(updatedBook);
            return NotFound();
        }


        //Add cost
        [HttpPut]
        [Route("api/books/updatecost/{id}")]
        public IHttpActionResult AddCost(int id, Cost cost)
        {
            var result = books.AddCost(id, cost);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}

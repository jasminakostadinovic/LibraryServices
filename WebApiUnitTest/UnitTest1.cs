using System;
using System.Web.Http;
using System.Web.Http.Results;
using LibraryServices.Controllers;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using LibraryServices.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApiUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var mockRepositoryClass = new Mock<IBookRepository>();

            mockRepositoryClass.Setup(x => x.GetBook(2)).Returns(new Book() { Id = 2 });
            var booksController = new BooksController(mockRepositoryClass.Object);

            //Act
            IHttpActionResult result = booksController.Get(2);
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(2, resultBook.Content.Id);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange

            var booksController = new BooksController(new BookDatabase());

            //Act

            IHttpActionResult result = booksController.Get(1);
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert

            Assert.AreEqual(1, resultBook.Content.Id);

            StringAssert.Contains(resultBook.Content.Author, "Hawkins");
        }
    }
}

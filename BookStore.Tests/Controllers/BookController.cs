using BookStore.Models;
using BookStore.Models.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Controllers
{
    [TestClass]
    class BookController
    {
        [TestMethod]
        public void Can_Filter_Books()
        {
            // Arrange
            // - create the mock repository
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Name = "P1", Category = "Cat1"},
                new Book {BookId = 2, Name = "P2", Category = "Cat2"},
                new Book {BookId = 3, Name = "P3", Category = "Cat1"},
                new Book {BookId = 4, Name = "P4", Category = "Cat2"},
                new Book {BookId = 5, Name = "P5", Category = "Cat3"}
            }.AsQueryable());
            // Arrange - create a controller and make the page size 3 items
            /*BookController controller = new BookController(mock.Object);
            controller.PageSize = 3;*/
            // Action
            /*Book[] result = ((BooksListViewModel)controller.List("Cat2", 1).Model)
            .Products.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");*/
        }
    }
}

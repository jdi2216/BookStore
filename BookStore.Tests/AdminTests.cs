using BookStore.Controllers;
using BookStore.Models;
using BookStore.Models.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests
{
    [TestClass]
    class AdminTests
    {
        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange - create the mock repository
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Name = "P1"},
                new Book {BookId = 2, Name = "P2"},
                new Book {BookId = 3, Name = "P3"},
            }.AsQueryable());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Book p1 = target.Edit(1).ViewData.Model as Book;
            Book p2 = target.Edit(2).ViewData.Model as Book;
            Book p3 = target.Edit(3).ViewData.Model as Book;
            // Assert
            Assert.AreEqual(1, p1.BookId);
            Assert.AreEqual(2, p2.BookId);
            Assert.AreEqual(3, p3.BookId);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Book()
        {
            // Arrange - create the mock repository
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Name = "P1"},
                new Book {BookId = 2, Name = "P2"},
                new Book {BookId = 3, Name = "P3"},
            }.AsQueryable());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act
            Book result = (Book)target.Edit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange - create a Product
            Book book = new Book { BookId = 2, Name = "Test" };
            // Arrange - create the mock repository
            Mock<IBooksRepository> mock = new Mock<IBooksRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                new Book {BookId = 1, Name = "P1"},
                book,
                new Book {BookId = 3, Name = "P3"},
                    }.AsQueryable());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act - delete the product
            target.Delete(book.BookId);
            // Assert - ensure that the repository delete method was
            // called with the correct Product
            mock.Verify(m => m.DeleteBook(book.BookId));
        }
    }
}

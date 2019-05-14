using BookStore.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Concrete
{
    public class EFBookRepository : IBooksRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Book> Books
        {
            get { return context.Books; }
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Add(book);
            }
            else
            {
                Book dbEntry = context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Publishing = book.Publishing;
                    dbEntry.Series = book.Series;
                    dbEntry.Binding = book.Binding;
                    dbEntry.NumberOfPages = book.NumberOfPages;
                    dbEntry.Price = book.Price;
                    dbEntry.DiscountPrice = book.DiscountPrice;
                    dbEntry.Quantity = book.Quantity;
                    dbEntry.Category = book.Category;
                    dbEntry.ImageData = book.ImageData;
                    dbEntry.ImageMimeType = book.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            Book dbEntry = context.Books.Find(bookId);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
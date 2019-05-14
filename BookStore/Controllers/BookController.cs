using BookStore.Models;
using BookStore.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBooksRepository repository;
        public int PageSize = 5;
        public BookController(IBooksRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Books.Count() :
                        repository.Books.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        /* [HttpPost]
         public async Task<ActionResult> Search(string searchString)
         {
             var books = from b in db.Books
                         select b;
             if (!String.IsNullOrEmpty(searchString))
             {
                 books = books.Where(s => s.Name.Contains(searchString));
             }

             return View(await books.ToListAsync());
         }*/

        public FileContentResult GetImage(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);
            if (book != null)
            {
                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}
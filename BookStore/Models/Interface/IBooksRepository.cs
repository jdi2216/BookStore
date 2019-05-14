using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interface
{
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; }

        void SaveBook(Book book);

        Book DeleteBook(int bookId);
    }
}

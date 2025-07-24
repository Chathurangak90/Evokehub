using BookStore.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.BookService
{
    public interface IBook
    {
        /// Interface retrieves all available books from different stores
        Task<List<Book>> GetAllBooks(int pageNumber = 1, int pageSize = 10);
    }
}

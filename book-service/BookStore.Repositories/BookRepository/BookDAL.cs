using BookStore.Models.BookModel;
using BookStore.Models.DTOs;
using BookStore.Services.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.BookRepository
{
    public class BookDAL : IBook
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookDAL(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        // Retrieves books from the bot store based on the given URLs.  
        public async Task<List<Book>> GetAllBooks(int pageNumber = 1, int pageSize = 10)
        {
            var books = new List<Book>();
            using var client = _httpClientFactory.CreateClient();

            try
            {
                var gretaBooks = await client.GetFromJsonAsync<List<BookDto>>("https://mybookstore.free.beeceptor.com/greta/books");
                if (gretaBooks != null)
                {
                    books.AddRange(gretaBooks.Select(b => new Book
                    {
                        Id = int.Parse(b.id),
                        Title = b.name,
                        Author = b.author,
                        Price = b.price,
                        Store = "Greta"
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching books from Greta's store: {ex.Message}");
            }

            try
            {
                var peterBooks = await client.GetFromJsonAsync<List<Book>>("https://mybookstore.free.beeceptor.com/peter/books");
                if (peterBooks != null)
                    books.AddRange(peterBooks.Select(b => { b.Store = "Peter"; return b; }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching books from Peter's store: {ex.Message}");
            }

            return books
                .OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


    }
}

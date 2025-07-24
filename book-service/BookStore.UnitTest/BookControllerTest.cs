using BookStore.Api.Controllers.BookController;
using BookStore.Models.BookModel;
using BookStore.Services.BookService;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace BookStore.UnitTest
{
    public class BookControllerTest
    {
        private readonly Mock<IBook> _bookServiceMock;
        private readonly BookController _controller;

        public BookControllerTest()
        {
            _bookServiceMock = new Mock<IBook>();
            _controller = new BookController(_bookServiceMock.Object);
        }

        [Fact]
        public async Task GetBooks_ShouldReturnListOfBooks()
        {
            // Arrange
            var allBooks = Enumerable.Range(1, 20).Select(i => new Book
            {
                Id = i,
                Title = $"Book {i}",
                Author = $"Author {i}",
                Price = 10 + i,
                Store = i % 2 == 0 ? "Greta" : "Peter"
            }).ToList();

            var pageNumber = 2;
            var pageSize = 5;
            var expectedPage = allBooks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            _bookServiceMock.Setup(s => s.GetAllBooks(pageNumber, pageSize)).ReturnsAsync(expectedPage);

            // Act
            var result = await _controller.GetAllBooks(pageNumber, pageSize);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(expectedPage);
        }
    }
}

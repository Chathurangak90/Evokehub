using BookStore.Api.Controllers.BookController;
using BookStore.Models.BookModel;
using BookStore.Models.Response;
using BookStore.Services.BookService;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTest
{
    public class OrderControllerTest
    {
        private readonly Mock<IOrder> _mockOrderService;
        private readonly OrderController _controller;

        public OrderControllerTest()
        {
            _mockOrderService = new Mock<IOrder>();
            _controller = new OrderController(_mockOrderService.Object);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturnOk_WhenOrderIsCreated()
        {
            // Arrange
            var order = new Order { Title = "Book", Price = 100, Store = "Greta" };
            var response = new ApiResponse<Order>
            {
                Success = true,
                Message = "Order created successfully",
                Data = order
            };

            _mockOrderService.Setup(s => s.CreateOrder(order)).ReturnsAsync(response);

            // Act
            var result = await _controller.CreateOrder(order);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            var apiResponse = okResult.Value as ApiResponse<Order>;
            apiResponse!.Success.Should().BeTrue();
            apiResponse.Data.Should().Be(order);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturnBadRequest_WhenOrderCreationFails()
        {
            // Arrange
            var order = new Order { Title = "Book", Price = 100, Store = "Peter" };
            var response = new ApiResponse<Order>
            {
                Success = false,
                Message = "Failed",
                Data = null
            };

            _mockOrderService.Setup(s => s.CreateOrder(order)).ReturnsAsync(response);

            // Act
            var result = await _controller.CreateOrder(order);

            // Assert
            var badResult = result.Result as BadRequestObjectResult;
            badResult.Should().NotBeNull();
            badResult!.StatusCode.Should().Be(400);
            var apiResponse = badResult.Value as ApiResponse<Order>;
            apiResponse!.Success.Should().BeFalse();
        }

        [Fact]
        public async Task GetOrders_ShouldReturnListOfOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { Title = "Book 1", Price = 50, Store = "Greta" },
                new Order { Title = "Book 2", Price = 75, Store = "Peter" }
            };

            _mockOrderService.Setup(s => s.GetAllOrders()).ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrders();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            var returnedOrders = okResult.Value as List<Order>;
            returnedOrders.Should().NotBeNull();
            returnedOrders.Should().HaveCount(2);
        }
    }
}

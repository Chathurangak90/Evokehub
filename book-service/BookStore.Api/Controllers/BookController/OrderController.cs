using BookStore.Models.BookModel;
using BookStore.Models.Response;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.BookController
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _iOrder;

        // Constructor with dependency injection for the IOrder service
        public OrderController(IOrder iOrder)
        {
            _iOrder = iOrder;
        }

        // Creates a new order
        [HttpPost("createorder")]
        public async Task<ActionResult<ApiResponse<Order>>> CreateOrder([FromBody] Order order)
        {
            var created = await _iOrder.CreateOrder(order);

            if (!created.Success)
            {
                // Return 400 Bad Request if creation failed
                return BadRequest(created);
            }
            return Ok(created);
        }

        // Retrieves all orders
        [HttpGet("getorders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _iOrder.GetAllOrders();
            return Ok(orders);
        }

    }
}

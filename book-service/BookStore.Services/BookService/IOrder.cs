using BookStore.Models.BookModel;
using BookStore.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.BookService
{
    public interface IOrder
    {
        // Creates a new order.
        Task<ApiResponse<Order>> CreateOrder(Order order);

        // Retrieves all orders.
        Task<List<Order>> GetAllOrders();
    }
}

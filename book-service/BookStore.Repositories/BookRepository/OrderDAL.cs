using BookStore.Models.BookModel;
using BookStore.Models.Response;
using BookStore.Repositories.Data;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repositories.BookRepository
{
    public class OrderDAL : IOrder
    {
        private readonly AppDbContext _context;

        public OrderDAL(AppDbContext context)
        {
            _context = context;
        }
        //create order
        public async Task<ApiResponse<Order>> CreateOrder(Order order)
        {
            if (order.Id != 0 && await _context.Orders.AnyAsync(o => o.Id == order.Id && o.Store == order.Store))
            {
                return new ApiResponse<Order>
                {
                    Success = false,
                    Message = $"The Book Name :{order.Title} already ordered.",
                    Data = null
                };
            }

            if (string.IsNullOrEmpty(order.OrderNumber))
            {
                order.OrderNumber = Guid.NewGuid().ToString("N")[..8].ToUpper();
            }

            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return new ApiResponse<Order>
                {
                    Success = true,
                    Message = "Order created successfully",
                    Data = order
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Order>
                {
                    Success = false,
                    Message = "Failed to create order: " + ex.Message,
                    Data = null
                };
            }
        }

        //load all orders
        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}

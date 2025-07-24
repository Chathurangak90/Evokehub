using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.BookModel
{
    public class Order
    {
        // Auto-incrementing primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Store { get; set; } = null!;
        public decimal TotalPaid => Price;
    }
}

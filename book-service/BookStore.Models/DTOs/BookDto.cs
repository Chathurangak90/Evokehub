using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.DTOs
{
    public class BookDto
    {
        public string id { get; set; }
        public string name { get; set; } 
        public string author { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
    }
}

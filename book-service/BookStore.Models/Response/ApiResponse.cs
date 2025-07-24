using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Response
{
    public class ApiResponse<Load>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Load? Data { get; set; }
    }

}

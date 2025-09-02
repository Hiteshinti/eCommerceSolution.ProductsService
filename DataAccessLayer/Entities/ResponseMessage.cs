using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ResponseMessage
    {
        public bool Success { get; set; }   
        public string? Message { get; set; } 
        public dynamic? data { get; set; }
        public int StatusCode { get; set; }
    }
}

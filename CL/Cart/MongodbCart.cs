using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Cart
{
    public class MongodbCart
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public int quantity { get; set; }
        public decimal totalAmount { get; set; }
    }
}

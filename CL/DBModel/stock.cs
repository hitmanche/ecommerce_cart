using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.DBModel
{
    public class stock
    {
        [Key]
        [Column(Order = 0)]
        public Int64 id { get; set; }
        [Key]
        [Column(Order = 1)]
        public Int64 product { get; set; }
        public DateTime using_date { get; set; }
        public decimal price { get; set; }
        public Int64 quantity { get; set; }
        public Int64 reserved_quantity { get; set; }
        public bool status { get; set; }
    }
}

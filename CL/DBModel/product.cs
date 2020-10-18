using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.DBModel
{
    public class product
    {
        [Key]
        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public bool status { get; set; }
        public bool deleted { get; set; }
    }
}

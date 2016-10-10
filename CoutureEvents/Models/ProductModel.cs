using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }

        public int? Quantity { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }

        private int _serviceID;

        [Range(0, double.MaxValue)]
        public int ServiceID
        {
            get
            {
                return _serviceID;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Cannot set a negative ID value");
                _serviceID = value;
            }
        }
    }
}
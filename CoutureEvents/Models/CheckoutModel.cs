using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class CheckoutModel
    {
        [CreditCard]
        public int CreditCard { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public int Phone { get; set; }
        public string Address { get; set; }
    }
}
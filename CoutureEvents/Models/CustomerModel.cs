using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string BrideFirstName { get; set; }
        public string BrideLastName { get; set; }
        public string GroomFirstName { get; set; }
        public string GroomLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime WeddingDate { get; set; }
        public int NumberOfGuests { get; set;}
        public int NumberOfBridesmaids { get; set; }
        public int NumberOfGroomsmen { get; set; }

    }
}
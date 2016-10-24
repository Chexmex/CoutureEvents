using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class AccountDetailsModel
    {
        [Phone]
        public string phoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        public string email { get; set; }
        [MinLength(7)]
        public string password { get; set; }
        [Phone]
        public string phoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
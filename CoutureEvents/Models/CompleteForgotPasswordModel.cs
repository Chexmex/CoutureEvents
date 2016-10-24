using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class CompleteForgotPasswordModel
    {
        public string NewPassword { get; set; }
        public string ResetToken { get; set; }
    }
}
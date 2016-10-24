using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoutureEvents.Models
{
    public class ProposalModel
    {
        public CustomerModel Customer { get; set; }
        public ProductModel Service { get; set; }
        public static int ProposalID { get; set; }
        
    }
}
using MyFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFlix.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VismaUtvikler.Models;

namespace VismaUtvikler.ViewModels
{
    public class CustomerViewModel
    {
        public Customer  Customer { get; set; }
        public List<CustomerContactPerson> ContactPersons { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }
        public List<CustomerToType> CustomerToTypes { get; set; }
    }
}
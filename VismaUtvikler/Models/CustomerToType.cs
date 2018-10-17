using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Models
{
    public class CustomerToType
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual  CustomerType CustomerType { get; set; }
    }
}
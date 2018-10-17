using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kunde kategori")]
        public string CustomerTypeName { get; set; }
        [Display(Name = "Beskrivelse av kundetype")]
        public string Description { get; set; }

        public virtual List<Customer> Customers { get; set; }
    }
}
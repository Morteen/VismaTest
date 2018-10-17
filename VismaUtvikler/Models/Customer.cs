using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Firma Navn")]
        public string FirmName { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Adress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Post Nummer")]
        public int PostalCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon nummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Fax nummer")]
        [DataType(DataType.PhoneNumber)]
        public string  FaxNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string MailAdress { get; set; }

        public virtual List<CustomerContactPerson> ContactPersons { get; set; }
        public virtual List<CustomerType> CustomerTypes { get; set; }

    }
}
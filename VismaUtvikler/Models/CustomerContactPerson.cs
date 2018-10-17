using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Models
{
    public class CustomerContactPerson
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Etternavn")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string Adress { get; set; }
        [DataType(DataType.PostalCode)]
        [Display(Name = "Post Nummer")]
        public int PostalCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon nummer")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        public string MailAdress { get; set; }

        // Fremmednøkler
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Dto
{
    public class ContactPersonDto
    {
        public int Id { get; set; }
      
        public string FirstName { get; set; }
        
        public string lastName { get; set; }
       
        public string Adress { get; set; }
        
        public int PostalCode { get; set; }
        
        public string PhoneNumber { get; set; }
       
        public string MailAdress { get; set; }
        public int CustomerId { get; set; }

    }

   


}
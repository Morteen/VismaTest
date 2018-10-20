using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VismaUtvikler.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirmName { get; set; }

        public string Adress { get; set; }

        public int PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string MailAdress { get; set; }
    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VismaUtvikler.Dto;
using VismaUtvikler.Models;

namespace VismaUtvikler.Controllers.Api
{
    public class ContactPersonsController : ApiController
    {
        //Skaffer database tilgang 
        private Models.ApplicationDbContext _context;

        public ContactPersonsController()
        {
            _context = new ApplicationDbContext();
        }


       // Finner hele med kontakt personer
        //Get /api/ContactPersons

        public IEnumerable<ContactPersonDto> GetContactPersons()
        {
            var contactPersons = _context.ContactPersons.ToList();

            return DtoHelper.MapContList(contactPersons);
        }


        // Finner  en contact person
        //Get /api/ContactPersons/1
        public ContactPersonDto GetContactPerson(int Id)
        {
            var contact= _context.ContactPersons.SingleOrDefault(c => c.Id == Id);
            if(contact==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            var dtoContact = DtoHelper.MapContactPersonToDtoPerson(contact);


            return dtoContact;
        }

    }
}

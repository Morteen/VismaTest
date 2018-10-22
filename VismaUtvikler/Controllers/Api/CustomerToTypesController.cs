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
    public class CustomerToTypesController : ApiController
    {
        //Skaffer database tilgang 
        private Models.ApplicationDbContext _context;

        public CustomerToTypesController()
        {
            _context = new ApplicationDbContext();
        }


        // Finner koblingene mellom firma og kundet ype
        //Get /api/CustomerToTypes

        public IEnumerable<CustomerToType> CustomerToTypes()
        {
            return null;
        }


        // Finner en eller flere kundetyper for et firma
        //Get /api/CustomerToTypes/1

        public IEnumerable<CustomerTypeDto> GetCustomerToTypes(int Id)
        {
            List<CustomerType> types = new List<CustomerType>();
            var customerToType = _context.CustomerToTypes.ToList();
            foreach (var type in customerToType)
            {
                types.Add(type.CustomerType);
            }
            return DtoHelper.MapTypeListToDtoList(types);
        }
        //DELETE /api/ContactPersons/1
        /*[HttpDelete]
        public IHttpActionResult DeleteContactPerson(int Id)
        {
            var contactPerson = _context.ContactPersons.Find(Id);
            if (contactPerson == null)
                return BadRequest();
            _context.ContactPersons.Remove(contactPerson);
            _context.SaveChanges();

            return Ok("Slettet");
        }

    }*/


    }
}

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
            var customerToType = _context.CustomerToTypes.Where(c=>c.CustomerId==Id).ToList();
            foreach (var type in customerToType)
            {
                types.Add(type.CustomerType);
            }
            return DtoHelper.MapTypeListToDtoList(types);
        }

        //Post /api/
        [HttpPost]
        public IHttpActionResult CreateCustomerToTypes(CustomerToTypeDto dtoCustomerToType)
        {
            var customerToType  = new CustomerToType();
            customerToType.CustomerId = dtoCustomerToType.CustomerId;
            customerToType.CustomerTypeId = dtoCustomerToType.CustomerTypeId;
            if (!ModelState.IsValid)
                return BadRequest();
            _context.CustomerToTypes.Add(customerToType);
            _context.SaveChanges();

            return
                Ok("Created success"); // Created(new Uri(Request.RequestUri + "/" + customerToType.Id), dtoCustomerToType);
        }


        //DELETE /api/CustomerToTypes/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomerToType(int customerId,int customerTypeId)
        {
            var customerToTypeInDb = _context.CustomerToTypes.Where(c=>c.CustomerTypeId==customerTypeId && c.CustomerId==customerId);//
            
            if (customerToTypeInDb == null)
                return BadRequest("Vi kommer hit ihvertfall");
              

            //Det skal ikke være mer en enn men dette ble løsningen
            foreach (var t in customerToTypeInDb)
            {
                _context.CustomerToTypes.Remove(t);
            }
           
            _context.SaveChanges();

            return Ok("Slettet");
        }


    }
}

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
    public class testController : ApiController
    {
        private Models.ApplicationDbContext _context;

        public testController()
        {
            _context = new ApplicationDbContext();
        }


        // Finner koblingene mellom firma og kundet ype
        //Get /api/test

        public IEnumerable<CustomerToTypeDto> GetTest()
        {
            var cToTypeList = _context.CustomerToTypes.ToList();
            var dtoList = DtoHelper.MapList(cToTypeList);
            return null;
        }


        // Finner en eller flere kundetyper for et firma
        //Get /api/Test/1

        public IEnumerable<CustomerDto> GetTest(int Id)
        {
            List<Customer> types = new List<Customer>();
            var customer = _context.CustomerToTypes.Where(c => c.CustomerTypeId == Id).ToList();
            foreach (var type in customer)
            {
                types.Add(type.Customer);
            }
            return DtoHelper.MapCustomerListToDto(types);
        }





    }
}

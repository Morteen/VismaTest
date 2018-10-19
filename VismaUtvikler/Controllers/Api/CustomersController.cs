﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VismaUtvikler.Models;

namespace VismaUtvikler.Controllers.Api
{
    public class CustomersController : ApiController
    {

        //Skaffer database tilgang 
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context= new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        //Get /api/customer/1
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if(customer==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }



        //Post /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }



        //Oppdatere en kunde
        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.Find(Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customer = _context.Customers.Find(Id);
            if(customer==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VismaUtvikler.Dto;
using VismaUtvikler.Models;

namespace VismaUtvikler.Controllers.Api
{
    public class CustomerTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CustomerTypes
        public IEnumerable<CustomerTypeDto>GetCustomerTypes()
        {
            return DtoHelper.MapTypeListToDtoList(db.CustomerTypes.ToList());
        }

        // GET: api/CustomerTypes/5
        [ResponseType(typeof(CustomerType))]
        public IHttpActionResult GetCustomerType(int id)
        {
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return NotFound();
            }

            return Ok(customerType);
        }

        // PUT: api/CustomerTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerType(int id, CustomerType customerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerType.Id)
            {
                return BadRequest();
            }

            db.Entry(customerType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerTypes
        [ResponseType(typeof(CustomerType))]
        public IHttpActionResult PostCustomerType(CustomerType customerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerTypes.Add(customerType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerType.Id }, customerType);
        }

        // DELETE: api/CustomerTypes/5
        [ResponseType(typeof(CustomerType))]
        public IHttpActionResult DeleteCustomerType(int id)
        {
            CustomerType customerType = db.CustomerTypes.Find(id);
            if (customerType == null)
            {
                return NotFound();
            }

            db.CustomerTypes.Remove(customerType);
            db.SaveChanges();

            return Ok(customerType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTypeExists(int id)
        {
            return db.CustomerTypes.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VismaUtvikler.Models;

namespace VismaUtvikler.Controllers
{
    public class CustomerToTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerToTypes
        public ActionResult Index()
        {
            var customerToTypes = db.CustomerToTypes.Include(c => c.Customer).Include(c => c.CustomerType);
            return View(customerToTypes.ToList());
        }

        // GET: CustomerToTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerToType customerToType = db.CustomerToTypes.Find(id);
            if (customerToType == null)
            {
                return HttpNotFound();
            }
            return View(customerToType);
        }

        // GET: CustomerToTypes/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirmName");
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "CustomerTypeName");
            return View();
        }

        // POST: CustomerToTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,CustomerTypeId")] CustomerToType customerToType)
        {
            if (ModelState.IsValid)
            {
                db.CustomerToTypes.Add(customerToType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirmName", customerToType.CustomerId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "CustomerTypeName", customerToType.CustomerTypeId);
            return View(customerToType);
        }

        // GET: CustomerToTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerToType customerToType = db.CustomerToTypes.Find(id);
            if (customerToType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirmName", customerToType.CustomerId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "CustomerTypeName", customerToType.CustomerTypeId);
            return View(customerToType);
        }

        // POST: CustomerToTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,CustomerTypeId")] CustomerToType customerToType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerToType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirmName", customerToType.CustomerId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "Id", "CustomerTypeName", customerToType.CustomerTypeId);
            return View(customerToType);
        }

        // GET: CustomerToTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerToType customerToType = db.CustomerToTypes.Find(id);
            if (customerToType == null)
            {
                return HttpNotFound();
            }
            return View(customerToType);
        }

        // POST: CustomerToTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerToType customerToType = db.CustomerToTypes.Find(id);
            db.CustomerToTypes.Remove(customerToType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

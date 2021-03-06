﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Customers
        //public ActionResult Index()
        //{
        //    return View(db.Customers.ToList());
        //}

        //Filter : Customers

        public ActionResult Index(string sortOrder, string searchString, int? id)
        {
            Employee employee = new Employee();
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var customerList = from s in db.Customers
                           select s;

            string currentUser = User.Identity.GetUserId();
            var employeeInfo = db.Employees.Where(c => c.UserId.Equals(currentUser)).Single();
            int theZipCode = employeeInfo.ZipCode;
            customerList = customerList.Where(s => s.ZipCode == theZipCode);

            if (!String.IsNullOrEmpty(searchString))
            {
                //int theZipCode = employee.ZipCode;
                //var theZipCode =  db.Employees.Include(p => p.ZipCode).Where(m => m.Id == id).Single();
                //customerList = customerList.Where(s => s.ZipCode == theZipCode);

                customerList = customerList.Where(s => s.PickUpDay.DayOfTheWeek.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customerList = customerList.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    customerList = customerList.OrderBy(s => s.ZipCode);
                    break;
                case "date_desc":
                    customerList = customerList.OrderBy(s => s.Address);
                    break;
                default:
                    customerList = customerList.OrderBy(s => s.LastName);
                    break;
            }

            return View(customerList.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Include(p=>p.PickUpDay).Where(m=>m.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer()
            {
                PickUpDays = db.PickUpDays.ToList()
            };

            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,PickUpDayID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.UserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id });
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer.PickUpDays = db.PickUpDays.ToList();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,ZipCode,PickUpDayID,ExtraDayPickUp,Invoice,Confirmation,DateStart,DateEnd")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id });
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        //[Authorize(Roles = "Employee")]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    customer.PickConfirmations = db.PickUpConfirmations.ToList();

        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Invoice,PickUpStatus")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Details", new { id = customer.Id });
        //    }
        //    return View(customer);
        //}


        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

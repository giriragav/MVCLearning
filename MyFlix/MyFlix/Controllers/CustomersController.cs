﻿using MyFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFlix.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers;

            return View(customers);
        }
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>(){ new Customer(){Name = "Giri", ID = 1 }, new Customer(){Name = "Preethi", ID = 2} };
        //}

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.ID==id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}
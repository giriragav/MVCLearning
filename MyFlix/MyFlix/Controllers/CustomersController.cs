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
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>(){ new Customer(){Name = "Giri", ID = 1 }, new Customer(){Name = "Preethi", ID = 2} };
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c=>c.ID==id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}
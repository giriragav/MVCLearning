using MyFlix.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFlix.ViewModels;

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
            var customers = _context.Customers.Include(c=>c.MembershipType);

            return View(customers);
        }
        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>(){ new Customer(){Name = "Giri", ID = 1 }, new Customer(){Name = "Preethi", ID = 2} };
        //}

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.ID==id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes;
            var viewModel = new CustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer.ID == 0)
                return HttpNotFound();

            var membershipTypes = _context.MembershipTypes;
            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.ID == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.ID == customer.ID);

                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeID = customer.MembershipTypeID;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }
    }
}

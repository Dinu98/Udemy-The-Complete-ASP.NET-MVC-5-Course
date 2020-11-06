using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private Dbctx db;

        public CustomersController()
        {
            db = new Dbctx();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public List<Customer> customers = new List<Customer>
            {
                new Customer {Name = "Customer1", Id = 1},
                new Customer {Name = "Customer2", Id = 2}
            };



        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = db.Customers.Include("MembershipType").ToList();
            var viewModel = new MoviesAndCustomersViewModel
            {
                Customers = customers
            };


            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.Find(id);

            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customers = new List<Customer>
            {
                new Customer {Name = "Customer1", Id = 1},
                new Customer {Name = "Customer2", Id = 2}
            };

        // GET: Customers
        [Route("customers")]
        public ActionResult Index()
        {
            var viewModel = new MoviesAndCustomersViewModel
            {
                Customers = customers
            };


            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = customers.Find(c => c.Id == id);

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
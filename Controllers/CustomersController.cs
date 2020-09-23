using Flixster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flixster.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){ Id = 0, Name = "John Wick" },
                new Customer(){ Id = 1, Name = "Michael Stevens" },
                new Customer(){ Id = 2, Name = "Chadwick Bosnan" }
            };
        }
    }
}

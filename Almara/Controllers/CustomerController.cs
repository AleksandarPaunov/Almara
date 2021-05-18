using Almara.Models;
using Almara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almara.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            var custList = new RandomMovieViewModel() 
            { Customers= customers };

            if (customers.Count==0)
            {
                return Content("Currently you dont have any customers");
            }
            return View(custList);
        }


        public ActionResult Details(int id)
        {
            var customers = GetCustomers();
            var cust = customers.SingleOrDefault(x => x.Id == id);
            if (cust==null)
            {
                return Content("No such customer found in the database!");
            }
            return View(cust);
        }
        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Name="Aleksandar Paunov",Id=1},
                new Customer{Name="Martin",Id=2},
                new Customer{Name="Rafaela Mavila",Id=3}
            };
        }
    }
}
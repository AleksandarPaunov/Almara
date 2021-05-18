using Almara.Models;
using Almara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Almara.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
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
            
            var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (cust==null)
            {
                return Content("No such customer found in the database!");
            }
            return View(cust);
        }
      
    }
}
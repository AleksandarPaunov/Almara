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
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View();
            }

            return View("ReadOnlyIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles=RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
            return View("CustomerForm", viewModel);

            }
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
            }
            else 
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();

            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
                
            };
            return View("CustomerForm",viewModel);
        }

        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membershipTypes
            };
             
            return View("CustomerForm",viewModel);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            Customer cust = _context.Customers.Include(c => c.MembershipType)
                .SingleOrDefault(x => x.Id == id);
            
            
            
            if (cust==null)
            {
                return Content("No such customer found in the database!");
            }
            return View(cust);
        }
      
    }
}
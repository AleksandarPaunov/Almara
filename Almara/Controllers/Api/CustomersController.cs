using Almara.Dtos;
using Almara.Models;
using Almara.Models.IdentityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Almara.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        [Authorize()]
        public IHttpActionResult GetCustomers()
        {
            var customersInDb = _context.Customers.Include(m => m.MembershipType).ToList();
            //Mapper.Map<MembershipType, MembershipTypeDto>(customersInDb, customerDtos);

            var customerDtos = customersInDb.ToList()
                                            .Select(Mapper.Map<Customer, CustomerDto>);

            





            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return NotFound();

            }

            return Ok( Mapper.Map<Customer,CustomerDto>(customer));
        
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri +"/"+customer.Id),customerDto);

            

        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb==null)
            {
                return NotFound();
            }
            customerDto.Id = customerInDb.Id;
            Mapper.Map(customerDto, customerInDb);
            
            

            _context.SaveChanges();

            return Ok();



        }
        //Delete /api/customers/1 
        [HttpDelete]
        public IHttpActionResult Delete (int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}

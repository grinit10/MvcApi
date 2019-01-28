using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAppy.Models;

namespace VidlyAppy.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GetAll api/Customers
        public IEnumerable<Customer> GetCustomers(string query = null)
        {
            var customersQuery = _context.customers.Include("MembershipType")
                .Where(c => c.Name.Contains(query));


            return customersQuery.ToList();
            
        }

        //GetCustomerById api/customers/1
        public IHttpActionResult GetCustomerById(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        //PostCustomer api/Customers
        [HttpPost]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.id), customer);
        }

        //EditCustomer api/Customers/1
        [HttpPut]
        public IHttpActionResult EditCustomer(int Id, Customer Customer)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == Id);
            if(customer == null)
            {
                return NotFound();
            }

           
            customer.Name = Customer.Name;
            customer.IsSubscribedNewsLetter = Customer.IsSubscribedNewsLetter;
            customer.MembershipTypeId = Customer.MembershipTypeId;
            customer.BirthDay = Customer.BirthDay;

            _context.SaveChanges();

            return Ok(Customer);
        }

        //DeleteCustomer api/customers/1
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.id == Id);
            if (customer == null)
                return NotFound();
            _context.customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}

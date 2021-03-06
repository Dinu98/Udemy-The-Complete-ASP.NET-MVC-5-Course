﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private Dbctx db;
        public CustomersController()
        {
            db = new Dbctx();
        }
        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerdto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerdto, customerInDb);

            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customerInDb.Id), customerdto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(customerInDb);

            db.SaveChanges();

            return Ok();
        }


    }
}

﻿using DeliveryServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceData.Implementation
{
    public class InMemoryRepositoryCustomer : IRepositoryCustomer
    { 
        private List<Customer> customers = new List<Customer>();

        public InMemoryRepositoryCustomer()
        {

        }

        public void Edit(Customer customer)
        {
            customers.Find(c => c.Id == customer.Id).FirstName = customer.FirstName;
            customers.Find(c => c.Id == customer.Id).LastName = customer.LastName;
            customers.Find(c => c.Id == customer.Id).UserName = customer.UserName;
            customers.Find(c => c.Id == customer.Id).Email = customer.Email;
            customers.Find(c => c.Id == customer.Id).PhoneNumber = customer.PhoneNumber;
            customers.Find(c => c.Id == customer.Id).Address = customer.Address;
            customers.Find(c => c.Id == customer.Id).PostalCode = customer.PostalCode;
        }

        public Customer FindOneByExpression(Expression<Func<Customer, bool>> expression)
        {
            return customers.SingleOrDefault(expression.Compile());
        }

        public List<Customer> GetAll()
        {
            return customers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppDB.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Customer customer)
        {
            _bankdbContext.Add(customer);
            _bankdbContext.SaveChanges();
        }

        public List<Customer> ReadAll()
        {
            var customers = _bankdbContext.Customer.ToListAsync().Result;

            return customers;
        }

        public Customer ReadById(long id)
        {
            var customer = _bankdbContext.Customer
                .Include(c => c.Account)
                .ThenInclude(c => c.Transaction)
                .FirstOrDefault(c => c.ID == id);
            return customer;
        }

        public void Update(long id, Customer customer)
        {
            var isAlive = ReadById(id);

            if (isAlive != null)
            {
                _bankdbContext.Update(customer);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Didn't find customer with id: {id}.");
            }
        }

        public void Delete(long id)
        {
            var deletedCustomer = ReadById(id);

            if (deletedCustomer != null)
            {
                _bankdbContext.Customer.Remove(deletedCustomer);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Didn't find customer with id: {id}.");
            }
        }
    }
}

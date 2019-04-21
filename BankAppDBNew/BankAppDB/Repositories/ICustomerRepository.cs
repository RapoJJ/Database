using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    interface ICustomerRepository
    {
        //CRUD
        void Create(Customer customer);
        List<Customer> ReadAll();
        Customer ReadById(long id);
        void Update(long id, Customer customer);
        void Delete(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Bank bank)
        {
            _bankdbContext.Add(bank);
            _bankdbContext.SaveChanges();
        }

        public List<Bank> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Bank ReadById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(long id, Bank bank)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppDB.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Account account)
        {
            _bankdbContext.Add(account);
            _bankdbContext.SaveChanges();
        }

        public List<Account> ReadAll()
        {
            var accounts = _bankdbContext.Account.ToListAsync().Result;
            return accounts;
        }

        public Account ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Account account)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}

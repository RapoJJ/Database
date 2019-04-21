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
            Console.WriteLine($"Account created with name: {account.Name} and IBAN: {account.IBAN}");
        }

        public List<Account> ReadAll()
        {
            var accounts = _bankdbContext.Account.ToListAsync().Result;
            return accounts;
        }

        public Account ReadById(string id)
        {
            var account = _bankdbContext.Account.Find(id);
            return account;
        }

        public void Update(string id, Account account)
        {
            var accExists = ReadById(id);

            if (accExists != null)
            {
                _bankdbContext.Update(account);
                _bankdbContext.SaveChanges();

            }
            else
            {
                Console.WriteLine($"Can't find account with this id {id}");
            }
        }

        public void Delete(string id)
        {
            var accExists = ReadById(id);

            if (accExists != null)
            {
                _bankdbContext.Account.Remove(accExists);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettiin!");
            }
            else
            {
                Console.WriteLine($"Ei löydetty tällä id:llä {id}");
            }
        }

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Transaction.Add(transaction);
            var account = ReadById(transaction.IBAN);
            account.Balance += transaction.Amount;

            _bankdbContext.Account.Update(account);
            _bankdbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAppDB.Models;
using Microsoft.EntityFrameworkCore;

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
            var banks = _bankdbContext.Bank.ToListAsync().Result;

            return banks;
        }

        public Bank ReadById(long id)
        {
            var bank = _bankdbContext.Bank
                .Include(b => b.Customer)
                .ThenInclude(b => b.Account)
                .FirstOrDefault(b => b.Id == id);
            return bank;
        }

        public void Update(long id, Bank bank)
        {
            var isAlive = ReadById(id);

            if (isAlive != null)
            {
                _bankdbContext.Update(bank);
                _bankdbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Bank with this id {id} couldn't be found!");
            }
        }

        public void Delete(long id)
        {
            var deletedBank = ReadById(id);

            if (deletedBank != null)
            {
                _bankdbContext.Bank.Remove(deletedBank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Bank was erased!");
            }
            else
            {
                Console.WriteLine($"Bank with this id {id} couldn't be found!");
            }
        }
    }
}

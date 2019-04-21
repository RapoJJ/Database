using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppDB.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();

        public void Create(Transaction transaction)
        {
            _bankdbContext.Add(transaction);
            _bankdbContext.SaveChanges();
            Console.WriteLine($"Added transaction with id: {transaction.Id} amount: {transaction.Amount} to {transaction.IBAN}");
        }

        public List<Transaction> ReadAll()
        {
            var transactions = _bankdbContext.Transaction.ToListAsync().Result;
            return transactions;
        }

        public Transaction ReadById(long id)
        {
            var transaction = _bankdbContext.Transaction.Find(id);
            return transaction;
        }

        public void Update(long id, Transaction transaction)
        {
            var isAlive = ReadById(id);

            if (isAlive != null)
            {
                _bankdbContext.Update(transaction);
                _bankdbContext.SaveChanges();
                Console.WriteLine($"Bank with id {transaction.Id} updated succesfully!");
            }
            else
            {
                Console.WriteLine($"Transaction with this id {id} couldn't be found!");
            }
        }

        public void Delete(long id)
        {
            var deletedTransaction = ReadById(id);

            if (deletedTransaction != null)
            {
                _bankdbContext.Transaction.Remove(deletedTransaction);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Transaction was erased!");
            }
            else
            {
                Console.WriteLine($"Transaction with this id {id} couldn't be found!");
            }
        }
    }
}

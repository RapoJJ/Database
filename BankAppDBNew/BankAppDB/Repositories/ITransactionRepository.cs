using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    interface ITransactionRepository
    {
        //CRUD
        void Create(Transaction transaction);
        List<Transaction> ReadAll();
        Transaction ReadById(long id);
        void Update(long id, Transaction transaction);
        void Delete(long id);
    }
}

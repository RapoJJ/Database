using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    interface IBankRepository
    {
        //CRUD
        void Create(Bank bank);
        List<Bank> ReadAll();
        Bank ReadById(long id);
        void Update(long id, Bank bank);
        void Delete(long id);
    }
}

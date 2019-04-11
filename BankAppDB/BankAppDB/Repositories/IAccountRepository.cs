using System.Collections.Generic;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        void Create(Account account);
        List<Account> ReadAll();
        Account ReadById(string id);
        void Update(string id, Account account);
        void Delete(string id);
    }
}
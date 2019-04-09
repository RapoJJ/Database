using System.Collections.Generic;
using BankAppDB.Models;

namespace BankAppDB.Repositories
{
    public interface IAccountRepository
    {
        //CRUD
        void Create(Account account);
        List<Account> ReadAll();
        Account ReadById(long id);
        void Update(long id, Account account);
        void Delete(long id);
    }
}
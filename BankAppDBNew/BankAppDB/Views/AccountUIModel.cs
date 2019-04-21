using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;
using BankAppDB.Repositories;

namespace BankAppDB.Views
{
    class AccountUIModel
    {
        private static readonly AccountRepository AccountRepository = new AccountRepository();

        public void PrintAccounts()
        {
            var accountList = AccountRepository.ReadAll();
            Console.WriteLine("List of accounts:");
            foreach (var b in accountList)
            {
                Console.WriteLine($"IBAN: {b.IBAN} Name: {b.Name}");
            }
        }

        public void CreateAccount()
        {
            Account newAccount = new Account
            {
                BankId = 1,
                CustomerId = 1,
                IBAN = "FI333322111",
                Balance = 200,
                Name = "Käyttötili"
            };
            AccountRepository.Create(newAccount);
        }

        public void DeleteAccount(string id)
        {
            Account deletedAccount = AccountRepository.ReadById(id);
            Console.WriteLine($"Account that is going to be deleted: {deletedAccount.Name} with iban: {deletedAccount.IBAN}");
            Console.Write("Are you sure? [Y/N]: ");

            char userInput = Console.ReadKey().KeyChar;

            if (userInput == 'Y' || userInput == 'y')
            {
                AccountRepository.Delete(id);
                Console.WriteLine("\nAccount deleted!");
            }
            else
            {
                Console.WriteLine("\nAccount wasn't deleted!");
            }
        }

        public void CreateTransaction()
        {
            Transaction newTransaction = new Transaction
            {
                IBAN = "FI333322111",
                Amount = 200,
            };

            AccountRepository.CreateTransaction(newTransaction);
        }

    }
}

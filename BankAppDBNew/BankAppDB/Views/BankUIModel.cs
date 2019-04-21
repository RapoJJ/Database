using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;
using BankAppDB.Repositories;

namespace BankAppDB.Views
{
    class BankUIModel
    {
        private static readonly BankRepository BankRepository = new BankRepository();
        
        public void ReadBanks()
        {
            var bankList = BankRepository.ReadAll();
            Console.WriteLine("List of banks:");
            foreach (var b in bankList)
            {
                Console.WriteLine($"ID: {b.Id} Name: {b.Name} BIC: {b.BIC} ");
            }
        }

        public void ReadBankById(long id)
        {
            var bank = BankRepository.ReadById(id);

            Console.WriteLine($"Bank {bank.Name} with Id {bank.Id} has the following accounts:");

            foreach (var account in bank.Account)
            {
                Console.WriteLine($"Account name: {account.Name} IBAN: {account.IBAN} Account owner is {account.Customer.LastName}");
            }

            Console.WriteLine($"Bank {bank.Name} has the following customers:");

            foreach (var customer in bank.Customer)
            {
                Console.WriteLine($"Customer full name: {customer.FirstName} {customer.LastName} Id: {customer.Id} ");
            }
        }

        public void CreateBank()
        {
            Bank newBank = new Bank
            {
                Name = "Nordea",
                BIC = "NDEAFIHH"
            };
            BankRepository.Create(newBank);
        }

        public void UpdateBank(long id)
        {
            Bank rBank = BankRepository.ReadById(id);

            rBank.Name = "OP-pankki";
            BankRepository.Update(id,rBank);

        }

        public void DeleteBank(long id)
        {
            Bank deletedBank = BankRepository.ReadById(id);
            Console.WriteLine($"Bank that is going to be deleted: {deletedBank.Name} with id: {deletedBank.Id}");
            Console.Write("Are you sure? [Y/N]: ");

            char userInput = Console.ReadKey().KeyChar;

            if (userInput == 'Y' || userInput == 'y')
            {
                BankRepository.Delete(id);
                Console.WriteLine("\nBank deleted!");
            }
            else
            {
                Console.WriteLine("\nBank wasn't deleted!");
            }
        }
    }
}

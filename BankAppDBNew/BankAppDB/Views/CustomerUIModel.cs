using System;
using System.Collections.Generic;
using System.Text;
using BankAppDB.Models;
using BankAppDB.Repositories;

namespace BankAppDB.Views
{
    class CustomerUIModel
    {
        private static readonly CustomerRepository CustomerRepository = new CustomerRepository();

        public void CreateCustomer()
        {
            Customer newCustomer = new Customer
            {
                FirstName = "Teppo",
                LastName = "Kokko",
                BankId = 3,
            };
            CustomerRepository.Create(newCustomer);
        }

        public void ReadCustomerById(long id)
        {
            var customer = CustomerRepository.ReadById(id);

            Console.WriteLine($"Customers info: {customer.FirstName} {customer.LastName}");
            Console.WriteLine("Customer has following accounts: ");
            foreach (var acc in customer.Account)
            {
                Console.WriteLine($"Account name: {acc.Name} IBAN: {acc.IBAN} Balance: {acc.Balance}");
                Console.WriteLine("This account has the following transactions: ");
                foreach (var trans in acc.Transaction)
                {
                    Console.WriteLine($"{trans.Amount} {trans.TimeStamp}");
                }
            }
        }

        public void DeleteCustomer(long id)
        {
            Customer deletedCustomer = CustomerRepository.ReadById(id);
            Console.WriteLine($"Bank that is going to be deleted: {deletedCustomer.FirstName} with id: {deletedCustomer.Id}");
            Console.Write("Are you sure? [Y/N]: ");

            char userInput = Console.ReadKey().KeyChar;

            if (userInput == 'Y' || userInput == 'y')
            {
                CustomerRepository.Delete(id);
                Console.WriteLine("\nCustomer deleted!");
            }
            else
            {
                Console.WriteLine("\nCustomer wasn't deleted!");
            }
        }

        public void UpdateCustomer(long id)
        {
            Customer rCustomer = CustomerRepository.ReadById(id);

            rCustomer.LastName = "Kataja";
            CustomerRepository.Update(id, rCustomer);

        }
    }
}

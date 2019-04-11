using System;
using BankAppDB.Models;
using BankAppDB.Repositories;

namespace BankAppDB
{
    class Program
    {
        static void Main(string[] args)
        {
            BankRepository bankRepository = new BankRepository();

            var bankList = bankRepository.ReadAll();


            foreach (var b in bankList)
            {
                Console.WriteLine($"{b.Name} {b.BIC} {b.Id}");

                foreach (var c in b.Account)
                {
                    Console.WriteLine($"Account name: {c.Name} Balance: {c.Balance}");
                }
            }


            var bank = bankRepository.ReadById(1);

            Console.WriteLine(bank.Name);


            /*Bank newBank = new Bank
            {
                Name = "Nordea",
                BIC = "NDEAFIHH"
            };*/
            //bankRepository.Create(newBank);

            //Bank updateBank = bankRepository.ReadById(3);

            //updateBank.BIC = "NDEAFIHH";

            //bankRepository.Update(3,updateBank);

            //bankRepository.Delete(5);
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Choose which data you want to view/edit:");
            Console.WriteLine("[1] Banks");
            Console.WriteLine("[2] Customers");
            Console.WriteLine("[Esc] Close the program.");
            Console.Write("Press key of your choice: ");
            return Console.ReadKey();
        }
    }
}

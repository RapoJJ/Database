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

            /*var bankList = bankRepository.ReadAll();


            foreach (var b in bankList)
            {
                Console.WriteLine($"{b.Name} {b.Bic} {b.ID}");
            }


            var bank = bankRepository.ReadById(1);

            Console.WriteLine(bank.Name);*/


            Bank newBank = new Bank
            {
                Name = "Nordea",
                Bic = "NDEAFIHH"
            };
            //bankRepository.Create(newBank);

            Bank updateBank = bankRepository.ReadById(3);

            updateBank.Bic = "NDEAFIHH";

            bankRepository.Update(3,updateBank);

            bankRepository.Delete(5);
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("[1] Read");
            Console.WriteLine("[2] ");
            Console.WriteLine("[3] ");
            Console.WriteLine("[4] ");
            Console.WriteLine("[5] ");
            Console.WriteLine("[Esc] Close the program.");
            Console.Write("Press key of your choice: ");
            return Console.ReadKey();
        }
    }
}

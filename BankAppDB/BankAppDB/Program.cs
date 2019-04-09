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
    }
}

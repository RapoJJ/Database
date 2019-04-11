using System;
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
                Console.WriteLine($"{b.Name} {b.Bic} {b.ID}");
            }


            var bank = bankRepository.ReadById(1);

            Console.WriteLine(bank.Name);
        }
    }
}

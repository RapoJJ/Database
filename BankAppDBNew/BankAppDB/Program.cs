using System;
using BankAppDB.Models;
using BankAppDB.Repositories;
using BankAppDB.Views;

namespace BankAppDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            do
            {
                cki = UserInterface();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        UserInterFaceBank();
                        break;
                    case ConsoleKey.D2:
                        UserInterfaceCustomer();
                        break;
                    case ConsoleKey.D3:

                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Program closes.");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }

                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();

            } while (cki.Key != ConsoleKey.Escape);
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

        private static void UserInterFaceBank()
        {
            BankUIModel uiModel = new BankUIModel();
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("You have chosen banks. Choose what you want to do:");

                Console.WriteLine("[1] Read all banks");
                Console.WriteLine("[2] Read bank by id and print all of banks info");
                Console.WriteLine("[3] Delete bank");
                Console.WriteLine("[4] Create new bank");
                Console.WriteLine("[5] Update bank info");
                Console.WriteLine("[Escape] Back to start.");
                Console.Write("Press the key of your choice: ");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        uiModel.ReadBanks();
                        break;
                    case ConsoleKey.D2:
                        uiModel.ReadBankById(1);
                        break;
                    case ConsoleKey.D3:
                        uiModel.DeleteBank(6);
                        break;
                    case ConsoleKey.D4:
                        uiModel.CreateBank();
                        break;
                    case ConsoleKey.D5:
                        uiModel.UpdateBank(7);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Going back to start.");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;

                }
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();


            } while (cki.Key != ConsoleKey.Escape);
        }


        private static void UserInterfaceCustomer()
        {
            CustomerUIModel customerUiModel = new CustomerUIModel();
            AccountUIModel accountUiModel = new AccountUIModel();
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("You have chosen customers. Choose what you want to do:");

                Console.WriteLine("[1] Read customers info by id");
                Console.WriteLine("[2] Delete customer");
                Console.WriteLine("[3] Create new customer");
                Console.WriteLine("[4] Update customer info");
                Console.WriteLine("[5] Create account for customer");
                Console.WriteLine("[6] Delete customers account");
                Console.WriteLine("[7] Create transactions to customers account");
                Console.WriteLine("[Escape] Back to start.");
                Console.Write("Press the key of your choice: ");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        customerUiModel.ReadCustomerById(1);
                        break;
                    case ConsoleKey.D2:
                        customerUiModel.DeleteCustomer(4);
                        break;
                    case ConsoleKey.D3:
                        customerUiModel.CreateCustomer();
                        break;
                    case ConsoleKey.D4:
                        customerUiModel.UpdateCustomer(2);
                        break;
                    case ConsoleKey.D5:
                        accountUiModel.CreateAccount();
                        break;
                    case ConsoleKey.D6:
                        accountUiModel.PrintAccounts();
                        accountUiModel.DeleteAccount("FI333322111");
                        break;
                    case ConsoleKey.D7:
                        accountUiModel.CreateTransaction();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Going back to start.");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;

                }
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();


            } while (cki.Key != ConsoleKey.Escape);
        }


    }
}
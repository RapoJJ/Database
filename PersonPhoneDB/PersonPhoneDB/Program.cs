using System;
using System.Collections.Generic;
using PersonPhoneDB.Models;
using PersonPhoneDB.Repositories;

namespace PersonPhoneDB
{
    class Program
    {
        private static readonly PersonRepository PersonRepository = new PersonRepository();
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            UIModel ui = new UIModel();
            do
            {
                cki = UserInterface();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        ui.ReadPersons();
                        break;
                    case ConsoleKey.D2:
                        ui.ReadPersonById();
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        ui.UpdatePerson();
                        break;
                    case ConsoleKey.D5:
                        ui.DeleteById();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Program closes.");
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }

                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                
            } while (cki.Key != ConsoleKey.Escape);
            
            Person newPerson = new Person();

            
        }
        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("[1] Print every persons info.");
            Console.WriteLine("[2] Find person by ID and print info.");
            Console.WriteLine("[3] Create person");
            Console.WriteLine("[4] Update persons info");
            Console.WriteLine("[5] Delete persons info");
            Console.WriteLine("[Esc] Exit");
            Console.Write("Press number key of your choice: ");
            return Console.ReadKey();
        }


    }
}
using System;
using PersonExampleDB.Models;
using PersonExampleDB.Repositories;
using PersonExampleDB.Views;

namespace PersonExampleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            UIModel uIModel = new UIModel();
            do
            {
                cki = UserInterface();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        uIModel.CreatePerson();
                        break;
                    case ConsoleKey.D2:
                        uIModel.ReadByCity();
                        break;
                    case ConsoleKey.D3:
                        for (int i = 1; i < 100; i++)
                        {
                            uIModel.ReadById(i);
                        }
                        break;
                    case ConsoleKey.D4:
                        uIModel.UpdatePerson();
                        break;
                    case ConsoleKey.D5:
                        uIModel.DeleteById(5006);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Ohjelma suljetaan.");
                        break;
                    default:
                        Console.WriteLine("Something happened.");
                        break;

                }
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }

        static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("Valitse mitä teet");
            Console.WriteLine("1. Lisää tietokantaan uusi tietue");
            Console.WriteLine("2. Lue tietyn kaupungin henkilöt");
            Console.WriteLine("3. Lue tietyn ID:n omaava henkilö");
            Console.WriteLine("4. Päivitä tietty henkilö");
            Console.WriteLine("5. Poista yksi henkilö");
            Console.WriteLine("Esc. Sulje ohjelma");
            Console.Write("Syötä valinta: ");
            
            return Console.ReadKey();
        }        
    }
}
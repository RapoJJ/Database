using System;
using PersonExampleDB.Models;
using PersonExampleDB.Repositories;

namespace PersonExampleDB
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            //Testing database Read
            //ReadByCity();

            //for (int i = 1; i < 100; i++)
            //{
            //    ReadById(i);              
            //}           
            //CreatePerson();
            ReadByCity();
        }

        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Lappeenranta");
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }

            Console.WriteLine("-----------------------");
        }

        static void ReadById(int id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
            {
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            }
            else
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
            }
        }

        static void CreatePerson()
        {
            Person p = new Person();
            p.FirstName = "Joonas";
            p.LastName = "Rapo";
            p.City = "Lappeenranta";
            p.ShoeSize = 42;

            _personRepository.Create(p);
        }
    }
}
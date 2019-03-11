using System;
using PersonExampleDB.Repositories;

namespace PersonExampleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing database Read
            PersonRepository personRepository = new PersonRepository();
            var persons = personRepository.ReadByCity("Juuka");
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }

            Console.WriteLine("-----------------------");
            var person = personRepository.ReadById(1210);

            Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
        }
    }
}
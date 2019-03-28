using System;
using System.Collections.Generic;
using System.Text;
using PersonPhoneDB.Models;
using PersonPhoneDB.Repositories;

namespace PersonPhoneDB
{
    class UIModel
    {
        private static readonly PersonRepository personRepository = new PersonRepository();


        public void ReadPersons()
        {
            foreach (var persons in personRepository.ReadAll())
            {
                Console.Write($"Name: {persons.Name} Age: {persons.Age} Phone numbers: ");

                foreach (var p in persons.Phone)
                {
                    Console.Write($"Type: {p.Type} Number: {p.Number} ");
                }

                Console.WriteLine();
            }
        }

        public void ReadPersonById()
        {

            var person = personRepository.ReadById(2);
            Console.Write($"Name: {person.Name} Age: {person.Age} Phone numbers: ");
            foreach (var p in person.Phone)
            {
                Console.Write($"Type: {p.Type} Number: {p.Number} ");
            }

            Console.WriteLine();
        }

        public void DeleteById()
        {
            personRepository.Delete(2);
        }

        public void UpdatePerson()
        {
            Person updatePerson = personRepository.ReadById(11);
            updatePerson.Name = "Pelle Peloton";
            updatePerson.Age = 65;
            updatePerson.Phone = new List<Phone>

            {
                new Phone { Type = "Home", Number = "0303030" }
            };

            personRepository.Update(11, updatePerson);
        }

        public void CreatePerson()
        {
            Person newPerson = new Person
            {
                Name = "Pöllö Peloton",
                Age = 60,
                Phone = new List<Phone>
            {
                new Phone{Number = "0404325613", Type = "Work"},
                new Phone{Number = "0406675423", Type = "Home"}
            }
            };

            personRepository.Create(newPerson);
        }
    }
}

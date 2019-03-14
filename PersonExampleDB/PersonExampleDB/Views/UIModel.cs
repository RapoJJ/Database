using PersonExampleDB.Models;
using PersonExampleDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonExampleDB.Views
{
    class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();


        public void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Lappeenranta");
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }

            Console.WriteLine("-----------------------");
        }

        public void ReadById(int id)
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

        public void CreatePerson()
        {
            Person p = new Person();
            p.FirstName = "Joonas";
            p.LastName = "Rapo";
            p.City = "Lappeenranta";
            p.ShoeSize = 42;

            _personRepository.Create(p);
            Console.WriteLine("Henkilön luonti onnistui!");
        }

        public void DeleteById(int id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }

        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(5003);
            updatePerson.FirstName = "Joonas";
            updatePerson.DateOfBirth = new DateTime(1992, 07, 10);
            updatePerson.Height = 178;
            updatePerson.EyeColor = "Blue";
            updatePerson.Sex = "Male";
            _personRepository.Update(5003, updatePerson);
        }
    }
}

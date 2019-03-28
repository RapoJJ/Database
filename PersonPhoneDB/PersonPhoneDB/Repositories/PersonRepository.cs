using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonPhoneDB.Models;

namespace PersonPhoneDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonphonedbContext _personphonedbContext = new PersonphonedbContext();
        public void Create(Person person)
        {
            _personphonedbContext.Add(person);
            _personphonedbContext.SaveChanges();
        }

        public List<Person> ReadAll()
        {
            var persons = _personphonedbContext.Person.
                Include(p =>p.Phone)
                .ToListAsync().Result;

            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _personphonedbContext.Person.Find(id);
            return person;
        }

        public void Update(long id, Person person)
        {
            var isAlive = ReadById(id);

            if (isAlive != null)
            {
                _personphonedbContext.Update(person);
                _personphonedbContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var deletedPerson = ReadById(id);

            if (deletedPerson != null)
            {
                _personphonedbContext.Person.Remove(deletedPerson);
                _personphonedbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettiin!");
            }
            else
            {
                Console.WriteLine($"Ei löydetty tällä id:llä {id}");
            }
        }
    }
}

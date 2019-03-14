using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonExampleDB.Models;
using System.Data.SqlClient;

namespace PersonExampleDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {
            string sql = $"INSERT INTO PERSON (FirstName, LastName, City, ShoeSize) " +
                         $"VALUES ({person.FirstName}, {person.FirstName}, {person.LastName},{person.City},{person.ShoeSize})";


            _persontestdbContext.Add(person);
            _persontestdbContext.SaveChanges();

        }

        public List<Person> Read()
        {
            var persons = _persontestdbContext.Person.ToListAsync().Result;
            return persons;
        }

        public List<Person> ReadByCity(string city)
        {
            //var persons = _persontestdbContext.Person.FromSql($"SELECT * FROM PERSON WHERE CITY = {city}").ToList();

            //var persons = _persontestdbContext.Person.Where(p => p.City == "Juuka").ToListAsync().Result;

            var persons = _persontestdbContext.Person.Where(p => p.City == city).ToListAsync().Result;

            return persons;
        }

        public Person ReadById(long id)
        {
            //var person = _persontestdbContext.Person.FromSql($"SELECT * FROM PERSON WHERE Id = {id}").Single();

            //var person = _persontestdbContext.
            //    Person.
            //    FirstOrDefault(p => p.Id == id);

            var person = _persontestdbContext.Person.Find(id);

            return person;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = ReadById(id);

            if (isPersonAlive != null)
            {
                _persontestdbContext.Update(person);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot päivitetty onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Tietojen päivitys epäonnistui - henkilöä ei ole olemassa!");
            }
        }

        public void Delete(long id)
        {
            var deletedPerson = _persontestdbContext.Person.Find(id);

            if (deletedPerson != null)
            {
                _persontestdbContext.Person.Remove(deletedPerson);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
            {
                Console.WriteLine("Henkilöä tällä id:llä ei löytynyt!");
            }
        }
    }
}
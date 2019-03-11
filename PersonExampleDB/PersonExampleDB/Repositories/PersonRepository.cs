using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonExampleDB.Models;

namespace PersonExampleDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            var persons = _persontestdbContext.Person.ToListAsync().Result;
            return persons;
        }

        public List<Person> ReadByCity(string city)
        {
            var persons = _persontestdbContext.Person.FromSql(
                $"SELECT * FROM PERSON WHERE CITY = {city}").ToList();

            //var persons = _persontestdbContext.Person.Where(p => p.City == "Juuka").ToListAsync().Result;

            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _persontestdbContext.Person.FromSql(
                $"SELECT * FROM PERSON WHERE Id = {id}").Single();

            return person;
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}

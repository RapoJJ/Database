using System;
using System.Collections.Generic;
using System.Text;
using PersonPhoneDB.Models;

namespace PersonPhoneDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);
        List<Person> ReadAll();
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}

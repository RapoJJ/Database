using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonExampleDB.Models;

namespace PersonExampleDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD - operation
        void Create(Person person);
        List<Person> Read();
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}

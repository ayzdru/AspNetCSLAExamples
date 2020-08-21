using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCSLAExamples.Core.Entities;

namespace AspNetCSLAExamples.Core.Interfaces
{
    public interface IPersonRepository
    {
        bool Exists(int id);
        Person Get(int id);
        List<Person> Get();
        Person Insert(Person person);
        Person Update(Person person);
        bool Delete(int id);
    }
}

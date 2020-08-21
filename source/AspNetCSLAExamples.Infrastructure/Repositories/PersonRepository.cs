using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCSLAExamples.Core.Entities;
using AspNetCSLAExamples.Core.Interfaces;
using AspNetCSLAExamples.Infrastructure.Data;


namespace AspNetCSLARazorPagesExample.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Delete(int id)
        {
            var person = _applicationDbContext.Persons.Where(p => p.Id == id).SingleOrDefault();
            if (person != null)
            {
                _applicationDbContext.Persons.Remove(person);
                return _applicationDbContext.SaveChanges() == 1;
            }
            else
            {
                return false;
            }
        }

        public bool Exists(int id)
        {
            var person = _applicationDbContext.Persons.Where(p => p.Id == id).SingleOrDefault();
            return !(person == null);
        }

        public Person Get(int id)
        {
            var person = _applicationDbContext.Persons.Where(p => p.Id == id).SingleOrDefault();
            if (person != null)
                return person;
            else
                throw new KeyNotFoundException($"Id {id}");
        }

        public List<Person> Get()
        {
            // return projection of entire list
            return _applicationDbContext.Persons.Where(r => true).ToList();
        }

        public Person Insert(Person person)
        {
            if (Exists(person.Id))
                throw new InvalidOperationException($"Key exists {person.Id}");
            _applicationDbContext.Persons.Add(person);
            _applicationDbContext.SaveChanges();

            return person;
        }

        public Person Update(Person person)
        {
            var p = Get(person.Id);
            p.Name = person.Name;
            _applicationDbContext.Persons.Update(p);
            _applicationDbContext.SaveChanges();
            return p;
        }
    }
}
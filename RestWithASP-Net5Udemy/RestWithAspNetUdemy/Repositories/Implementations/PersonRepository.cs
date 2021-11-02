using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASP_Net5Udemy.Models;
using RestWithASP_Net5Udemy.Repositories;
using RestWithAspNetUdemy.Contexts;

namespace RestWithAspNetUdemy.Repositories.Implementations
{
    class PersonRepository : IPersonRepository
    {

        private readonly MysqlContext _context;

        public PersonRepository(MysqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return person;
        }

        public void Delete(long id)
        {
            _context.Remove(_context.Persons.SingleOrDefault(p => p.Id.Equals(id)));
            _context.SaveChanges();
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            var personUpdate = FindById(person.Id);

            if (personUpdate != null)
            {
                try
                {
                    _context.Entry(personUpdate).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return person;
            }

            return null;
        }
    }
}
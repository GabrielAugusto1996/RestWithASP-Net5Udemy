using System.Collections.Generic;
using System.Linq;
using RestWithASP_Net5Udemy.Models;
using RestWithASP_Net5Udemy.Services;
using RestWithAspNetUdemy.Contexts;

namespace RestWithAspNetUdemy.Services.Implementations
{
    class PersonService : IPersonService
    {

        private readonly MysqlContext _context;

        public PersonService(MysqlContext context)
        {
            _context = context;
        }        

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Gabriel",
                LastName = "Augusto",
                Address = "Belo Horizonte - MG",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
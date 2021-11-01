using System.Collections.Generic;
using RestWithASP_Net5Udemy.Models;
using RestWithASP_Net5Udemy.Services;

namespace RestWithAspNetUdemy.Services.Implementations
{
    class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            return new List<Person> {
                FindById(5),
                FindById(9)
            };
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
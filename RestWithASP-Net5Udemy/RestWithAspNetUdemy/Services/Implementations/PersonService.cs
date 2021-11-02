using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASP_Net5Udemy.Models;
using RestWithASP_Net5Udemy.Repositories;
using RestWithASP_Net5Udemy.Services;

namespace RestWithAspNetUdemy.Services.Implementations
{
    class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            try
            {
                return _personRepository.Create(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _personRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            try
            {
                return _personRepository.Update(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
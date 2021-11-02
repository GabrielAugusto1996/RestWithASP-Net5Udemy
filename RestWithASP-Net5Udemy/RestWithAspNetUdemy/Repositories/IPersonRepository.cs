using System.Collections.Generic;
using RestWithASP_Net5Udemy.Models;

namespace RestWithASP_Net5Udemy.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        void Delete(long id);
        Person Update(Person person);
        List<Person> FindAll();
    }
}
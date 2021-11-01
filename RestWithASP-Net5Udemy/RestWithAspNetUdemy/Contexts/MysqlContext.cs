using Microsoft.EntityFrameworkCore;
using RestWithASP_Net5Udemy.Models;

namespace RestWithAspNetUdemy.Contexts
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(): base() {}

        public MysqlContext(DbContextOptions<MysqlContext> options): base(options){}

        public DbSet<Person> Persons {get; set;}
    }
}
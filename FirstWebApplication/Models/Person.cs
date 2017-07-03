using System;
using System.Data.Entity;

namespace FirstWebApplication.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class PersonDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
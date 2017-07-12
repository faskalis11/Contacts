using Contacts.Data.Models;
using System.Data.Entity;

namespace Contacts.Data.Entities
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ContactsConnectionString")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
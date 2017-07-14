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
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .ToTable("Contacts");

            modelBuilder.Entity<Message>()
                .ToTable("Messages");

        }
    }
}
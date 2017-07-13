using Contacts.Data.Entities;
using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using System.Collections.Generic;

namespace Contacts.Data.Repositories.Database
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context = new DataContext();

        public Contact Create(Contact contact)
        {

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Find(id));
            _context.SaveChanges();
        }

        public Contact Update(Contact contact)
        {
            var oldContact = _context.Contacts.Find(contact.Id);
            oldContact.Name = contact.Name;
            oldContact.Email = contact.Email;
            oldContact.Phone = contact.Phone;
            _context.SaveChanges();

            return contact;
        }

        public IEnumerable<Contact> Get()
        {

            return _context.Contacts;
        }

        public Contact Get(int id)
        {
            return _context.Contacts.Find(id);
        }
    }
}
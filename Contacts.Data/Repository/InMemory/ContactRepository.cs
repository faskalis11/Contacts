using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using System.Collections.Generic;

namespace Contacts.Data.Repositories.InMemory
{
    public class ContactRepository : IContactRepository
    {
        private static int currentId = 0;
        private static Dictionary<int, Contact> contactsDictionary = new Dictionary<int, Contact>();

        public Contact Create(Contact contact)
        {

            currentId++;
            contact.Id = currentId;

            contactsDictionary.Add(currentId, contact);
            
            return contact;
        }

        public void Delete(int Id)
        {
            if (contactsDictionary.ContainsKey(Id))
            {
                contactsDictionary.Remove(Id);
            }
        }

        public Contact Update(Contact contact)
        {
            contactsDictionary[contact.Id] = contact;
            return contact;
        }

        public IEnumerable<Contact> Get()
        {
            return contactsDictionary.Values;
        }

        public Contact Get(int id)
        {
            if (contactsDictionary.ContainsKey(id))
            {
          
                Contact contact = contactsDictionary[id];
                return contact;
            }
            else
            {
                return null;
            }
        }
    }
}
using FirstWebApplication.Data.ContactAPI;
using FirstWebApplication.Data.Models;
using System;
using System.Collections.Generic;

namespace FirstWebApplication.Data.Repositories
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
            throw new NotImplementedException();
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
using FirstWebApplication.Data.Models;
using System.Collections.Generic;

namespace FirstWebApplication.Data.ContactAPI
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact Get(int id);
        Contact Create(Contact contact);
        void Delete(int Id);
        Contact Update(Contact contact);
    }
}

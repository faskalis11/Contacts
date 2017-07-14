using Contacts.Data.Models;
using System.Collections.Generic;

namespace Contacts.Data.ContactAPI
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Get();
        Message Get(int id);
        Message Create(Message contact);
        void Delete(int id);
        Message Update(Message contact);
        IEnumerable<Message> GetByContact();
    }
}

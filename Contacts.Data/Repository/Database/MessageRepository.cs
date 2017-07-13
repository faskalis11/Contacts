using System;
using System.Collections.Generic;
using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using Contacts.Data.Entities;

namespace Contacts.Data.Repository.Database
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context = new DataContext();

        public Message Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public void Delete(int Id)
        {
            _context.Messages.Remove(_context.Messages.Find(Id));
            _context.SaveChanges();
        }

        public IEnumerable<Message> Get()
        {
            return _context.Messages;
        }

        public Message Get(int id)
        {
            return _context.Messages.Find(id);
        }

        public Message Update(Message message)
        {
            var oldMessage = _context.Messages.Find(message.Id);
            oldMessage.MessageText = message.MessageText;
            oldMessage.ReceiverId = message.ReceiverId;
            oldMessage.SenderId = message.SenderId;
            oldMessage.HasBeenSent = message.HasBeenSent;
            _context.SaveChanges();
            return message;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Models
{
    public class Message
    {
        public int Id { set; get; }
        public string MessageText { set; get; }
        public int SenderId { set; get; }
        public int ReceiverId { set; get; }
        public bool HasBeenSent { set; get; }
    }
}

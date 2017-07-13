using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Contacts.Data.Repository.Database;

namespace Contacts.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessageApiController : ApiController
    {
        
        private readonly IMessageRepository _messageRepository;

        public MessageApiController()
        {
            _messageRepository = new MessageRepository();
        }

        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
            return _messageRepository.Get();
        }

        [HttpGet]
        public IHttpActionResult GetMessage(int id)
        {
            Message message = _messageRepository.Get(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        [HttpPut]
        public IHttpActionResult PutMessage(int id, Message message)
        {
            _messageRepository.Update(message);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult PostMessage(int id, [FromBody] Message message)
        {
            //message
            message.HasBeenSent = false;
            message.ReceiverId = id;
            message.SenderId = id;
            _messageRepository.Create(message);
            return Ok(message);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMessage(int id)
        {
            var message = _messageRepository.Get(id);
            if (message == null)
            {
                return BadRequest();
            }

            _messageRepository.Delete(id);

            return Ok(message);
        }
    }
}
using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using Contacts.Data.Repository.Database;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Contacts.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class MessageApiController : ApiController
    {
        
        private readonly IMessageRepository _messageRepository;

        public MessageApiController()
        {
            _messageRepository = new MessageRepository();
        }

        [HttpGet]
        public IHttpActionResult GetMessages()
        {
            try
            {
                var req = Request;
                return Ok(_messageRepository.Get());
            }
            catch (System.Exception ex)
            {
                var a = ex.Message;
            }
            return BadRequest();

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
            message.ReceiverId = id;
            message.SenderId = id;
            _messageRepository.Create(message);

            if (message.HasBeenSent == true)
            {
                var T = Task.Run(() => new SMSController().MessageResponse(message));
            }
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
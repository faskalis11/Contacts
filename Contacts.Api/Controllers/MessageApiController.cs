using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using Contacts.Data.Repository.Database;
using NLog;
using System;
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
        private readonly SmsController _smsController;
        private readonly EmailController _emailController;
        public MessageApiController()
        {

        }

        Logger logger = LogManager.GetCurrentClassLogger(); 

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
            catch (Exception ex)
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
        public async Task<IHttpActionResult> PostMessage(int id, [FromBody] Message message)
        {
            try
            {
                message.ReceiverId = id;
                message.SenderId = id;
                _messageRepository.Create(message);
                if (message.HasBeenSent == true) //atskirti
                {
                    //var TSms = Task.Run(() => new SmsController().MessageResponse(message));
                    //var TMail = Task.Run(() => new EmailController().SendMail(message));
                    await _emailController.SendMail(message);
                }
                return Ok(message);
            }
            catch (Exception ex)
            {
                
                logger.Error("Something went wrong :(" + ex);
                return BadRequest();
            }
            
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
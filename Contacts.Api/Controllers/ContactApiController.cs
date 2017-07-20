using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using NLog;
using System;
using System.Web.Http;


namespace Contacts.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ContactApiController : ApiController
    {
        private readonly IContactRepository _contactRepository;
        Logger logger = LogManager.GetCurrentClassLogger(); //DI

        public ContactApiController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public  IHttpActionResult Get()
        {
            try
            {
                var req = Request;
                return Ok(_contactRepository.Get());
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var contact = _contactRepository.Get(id);
            if (contact == null)
            {
                return BadRequest();
            }
            _contactRepository.Delete(id);
            return Ok(contact);
        }

        [HttpPut]
        public IHttpActionResult Put(Contact contact)
        {
            _contactRepository.Update(contact);
            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult Post(Contact contact)
        {
            try
            {
                _contactRepository.Create(contact);
                return Ok(contact);

            } catch (Exception ex)
            {
                
                logger.Error("Something went wrong :(" + ex);
                return BadRequest();
            }
        }
    }
}

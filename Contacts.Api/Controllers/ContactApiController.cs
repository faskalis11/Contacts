using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Database;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Contacts.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactApiController : ApiController
    {
        private readonly IContactRepository _contactRepository;

        public ContactApiController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactRepository.Get();
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
            //Validacija
            _contactRepository.Update(contact);
            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult Post(Contact contact)
        {
            //validacija
            _contactRepository.Create(contact);
            return Ok(contact);
        }

    }
}

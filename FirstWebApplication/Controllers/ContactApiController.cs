using FirstWebApplication.Data.ContactAPI;
using FirstWebApplication.Data.Models;
using FirstWebApplication.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebApplication.Controllers
{
    public class ContactApiController : ApiController
    {
        private static IContactRepository _contactRepository;

        public ContactApiController()
        {
            _contactRepository = new ContactRepository();
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

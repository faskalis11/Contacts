using FirstWebApplication.Data.ContactAPI;
using FirstWebApplication.Data.Models;
using FirstWebApplication.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepository.Get();
        }

        public IHttpActionResult GetContactById(int id)
        {
            var contact = _contactRepository.Get().FirstOrDefault((c) => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

    }
}

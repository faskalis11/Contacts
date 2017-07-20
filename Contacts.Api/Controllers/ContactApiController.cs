using Contacts.Data.ContactAPI;
using Contacts.Data.Models;
using System.Web.Http;


namespace Contacts.Api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ContactApiController : ApiController
    {
        private readonly IContactRepository _contactRepository;

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
            catch (System.Exception ex)
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

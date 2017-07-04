using System.Web.Mvc;
using FirstWebApplication.Data.Models;
using FirstWebApplication.Data.Repositories;
using FirstWebApplication.Data.ContactAPI;

namespace FirstWebApplication.Controllers
{
    public class ContactController : Controller
    {
        private static IContactRepository _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = _contactRepository.Get();

            return View(contacts);
        }

        //// GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {

            if (contact.Email == null || contact.Name == null || contact.Email.Trim().Length == 0 || contact.Name.Trim().Length == 0 || !contact.Email.Contains("@"))
            {
                return View();
            }

            //Phone number be empty, 861234567 and +37061234567
            if (contact.Phone ==null || contact.Phone.Length == 0 || contact.Phone.Length == 9 || contact.Phone.Length == 12)
            {
                _contactRepository.Create(contact);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Contact/Delete
        public ActionResult Delete()
        {

            return View();
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Contact contact = _contactRepository.Get(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            Contact contact = _contactRepository.Get(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            _contactRepository.Delete(id.Value);

            return RedirectToAction("Index");
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }else
            {
                Contact contact = _contactRepository.Get(id.Value);
                return View(contact);
            }
        }
    }
}
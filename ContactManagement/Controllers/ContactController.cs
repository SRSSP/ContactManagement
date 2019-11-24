using BusinessAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Web.Mvc;

namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        public ActionResult GetAllContacts()
        {
            try
            {
                var contacts = _repository.GetAllContacts();
                return View(contacts);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult GetDetails(int id)
        {
            try
            {
                var contact = _repository.GetDetail(id);
                return View(contact);

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(ContactEntity contactEntity)
        {
            try
            {
                _repository.AddContact(contactEntity);
                return RedirectToAction("GetAllContacts");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult EditContact(int id)
        {
            try
            {
                var contact = _repository.GetDetail(id);
                return View(contact);

            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EditContact(int id, ContactEntity contactEntity)
        {
            try
            {
                _repository.UpdateContact(id, contactEntity);
                return RedirectToAction("GetAllContacts");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult DeleteContact(int id)
        {
            try
            {
                var contact = _repository.GetDetail(id);
                return View(contact);

            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult DeleteContact(int id, ContactEntity collection)
        {
            try
            {
                _repository.RemoveContact(id);
                return RedirectToAction("GetAllContacts");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}

using AutoMapper;
using BusinessAccessLayer;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IContactManagementDbContext _dbContext;

        public ContactRepository(IContactManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ContactEntity> GetAllContacts()
        {
            var contacts = _dbContext.Contacts.ToList();
            return Mapper.Map<List<ContactEntity>>(contacts);
        }

        public ContactEntity GetDetail(int contactId)
        {
            var contact = _dbContext.Contacts.Single(c => c.ContactId == contactId);
            return Mapper.Map<ContactEntity>(contact);
        }

        public void AddContact(ContactEntity contact)
        {
            var _contact = Mapper.Map<Contact>(contact);
            _dbContext.Contacts.Add(_contact);
            _dbContext.SaveChanges();
        }

        public void UpdateContact(int contactId, ContactEntity contact)
        {
            var _contact = _dbContext.Contacts.Single(c => c.ContactId == contactId);

            _contact.FirstName = contact.FirstName;
            _contact.LastName = contact.LastName;
            _contact.Email = contact.Email;
            _contact.PhoneNumber = contact.PhoneNumber;
            _contact.Status = contact.Status;

            _dbContext.Contacts.AddOrUpdate(_contact);
            _dbContext.SaveChanges();
        }

        public void RemoveContact(int contactId)
        {
            var contact = _dbContext.Contacts.Single(c => c.ContactId == contactId);

            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }
    }
}

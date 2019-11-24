using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer;

namespace DataAccessLayer.Repository
{
    public interface IContactRepository
    {
        List<ContactEntity> GetAllContacts();
        ContactEntity GetDetail(int contactId);
        void AddContact(ContactEntity contacts);
        void UpdateContact(int contactId, ContactEntity contact);
        void RemoveContact(int contactId);
    }
}

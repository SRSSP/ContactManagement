using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IContactManagementDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        int SaveChanges();
    }
}

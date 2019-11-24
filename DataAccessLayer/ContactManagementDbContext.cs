using System.Configuration;
using System.Data.Entity;
using Microsoft.Azure;

namespace DataAccessLayer
{
    public class ContactManagementDbContext : DbContext, IContactManagementDbContext
    {
        public ContactManagementDbContext() : base(CloudConfigurationManager.GetSetting("ContactManagementConnectionString"))
        {
            Database.SetInitializer<ContactManagementDbContext>(null);
        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ContactManagement");
            base.OnModelCreating(modelBuilder);
        }
    }
}

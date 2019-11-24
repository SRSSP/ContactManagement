using AutoMapper;
using BusinessAccessLayer;

namespace DataAccessLayer
{
    public static class AutoMapperBootstrapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contact, ContactEntity>();
                cfg.CreateMap<ContactEntity, Contact>();
            });
        }
    }
}

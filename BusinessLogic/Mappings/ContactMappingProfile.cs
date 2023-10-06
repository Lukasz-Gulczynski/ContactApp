using AutoMapper;
using ContactsApp.Core.Dtos;
using ContactsApp.Core.Models;
using static ContactsApp.Core.Dtos.ContactDto;

namespace ContactsApp.Core.Mappings
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDto>();

            CreateMap<ContactCreationDto, Contact>();

            CreateMap<ContactUpdateDto, Contact>().ReverseMap();
        }
    }
}

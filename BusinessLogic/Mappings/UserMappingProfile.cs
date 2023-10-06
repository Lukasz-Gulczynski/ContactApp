using AutoMapper;
using ContactsApp.Core.Dtos;
using ContactsApp.Core.Models;

namespace ContactsApp.Core.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}

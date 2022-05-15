using AutoMapper;
using RiseTechnology.Application.PersonContacts.Commands.CreatePersonContact;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.PersonContacts.MappingProfiles
{
    public class PersonContactMappingProfiles: Profile
    {
        public PersonContactMappingProfiles()
        {
            CreateMap<CreatePersonContactCommand, PersonContact>();
        }
    }
}

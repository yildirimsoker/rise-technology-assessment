using AutoMapper;
using RiseTechnology.Application.Persons.Commands.CreatePerson;
using RiseTechnology.Application.Persons.Commands.UpdatePerson;
using RiseTechnology.Application.Persons.Queries.GetPersonById;
using RiseTechnology.Application.Persons.Queries.GetPersonsWithPagination;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Persons.MappingProfiles
{
    public class PersonMappingProfiles: Profile
    {
        public PersonMappingProfiles()
        {
            CreateMap<CreatePersonCommand, Person>();
            CreateMap<UpdatePersonCommand, Person>();
            CreateMap<Person, GetPersonsWithPaginationDTO>();
            CreateMap<PersonContact, GetPersonByIdContactDTO>();
            CreateMap<Person, GetPersonByIdDTO>()
               .ForMember(dest => dest.PersonContact,opt => opt.MapFrom(src => src.PersonContact));
        }
    }
}

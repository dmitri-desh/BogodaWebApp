using AutoMapper;
using System.Diagnostics;
using WebApi.Domain;
using WebApi.DTOs;

namespace WebApi.Mapping
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<CreateContactDTO, Contact>();
            CreateMap<UpdateContactDTO, Contact>();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

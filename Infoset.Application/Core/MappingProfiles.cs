using AutoMapper;
using Infoset.Domain;

namespace Infoset.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Branche, Branche>();
        }
    }
}

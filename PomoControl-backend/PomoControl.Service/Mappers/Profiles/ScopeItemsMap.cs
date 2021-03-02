using AutoMapper;
using PomoControl.Service.Dtos;
using PomoControl.Domain;

namespace PomoControl.Service.Mappers.Profiles
{
    class ScopeItemsMap : Profile
    {
        public ScopeItemsMap()
        {
            CreateMap<ScopeItem, ScopeItemsDto>();
            CreateMap<ScopeItemsDto, ScopeItem>();
        }
    }
}

using AutoMapper;
using PomoControl.Service.Dtos;
using PomoControll.Model;

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

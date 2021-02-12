using AutoMapper;
using PomoControl.BLL.Dtos;
using PomoControll.Model;

namespace PomoControl.BLL.Mappers.Profiles
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

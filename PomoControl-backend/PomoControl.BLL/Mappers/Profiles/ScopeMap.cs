using AutoMapper;
using PomoControl.BLL.Dtos;
using PomoControll.Model;

namespace PomoControl.BLL.Mappers.Profiles
{
    class ScopeMap : Profile
    {
        public ScopeMap()
        {
            CreateMap<Scope, ScopeDto>();
            CreateMap<ScopeDto, Scope>();
        }
    }
}

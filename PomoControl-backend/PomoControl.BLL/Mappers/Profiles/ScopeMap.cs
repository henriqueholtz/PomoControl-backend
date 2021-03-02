using AutoMapper;
using PomoControl.Service.Dtos;
using PomoControll.Model;

namespace PomoControl.Service.Mappers.Profiles
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

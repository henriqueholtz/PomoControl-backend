using AutoMapper;
using PomoControl.Service.Dtos;
using PomoControl.Domain;

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

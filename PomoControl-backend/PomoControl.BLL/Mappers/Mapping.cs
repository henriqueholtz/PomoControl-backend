using AutoMapper;
using PomoControl.Service.Mappers.Profiles;
using System;

namespace PomoControl.Service.Mappers
{
    class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                //this line ensures that internal properties are also mapped over
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ScopeMap>();
                cfg.AddProfile<ScopeItemsMap>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
    }
}

using AutoMapper;
using PomoControl.Infraestructure.Interfaces;
using PomoControl.Service.DTO;
using PomoControl.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Services
{
    public class ScopeService : IScopeService
    {
        private readonly IMapper _mapper;
        private readonly IScopeRepository _scopeRepository;

        public ScopeService(IMapper mapper, IScopeRepository scopeRepository)
        {
            _mapper = mapper;
            _scopeRepository = scopeRepository;
        }

        public async Task<ScopeDTO> Create(ScopeDTO scopeDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ScopeDTO> Get(int code)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScopeDTO>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ScopeDTO> Update(ScopeDTO scopeDTO)
        {
            throw new NotImplementedException();
        }
    }
}

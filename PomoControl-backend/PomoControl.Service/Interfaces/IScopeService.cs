using PomoControl.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IScopeService
    {
        Task<ScopeDTO> Create(ScopeDTO scopeDTO);
        Task<ScopeDTO> Update(ScopeDTO scopeDTO);
        Task Remove(int code);
        Task<ScopeDTO> Get(int code);
        Task<List<ScopeDTO>> SearchByName(string name);
    }
}

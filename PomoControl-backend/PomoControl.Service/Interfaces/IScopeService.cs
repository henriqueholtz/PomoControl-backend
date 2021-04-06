using PomoControl.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IScopeService
    {
        Task<ResponseServiceDTO> Create(ScopeDTO scopeDTO);
        Task<ResponseServiceDTO> Update(ScopeDTO scopeDTO);
        Task Remove(int code);
        Task<ResponseServiceDTO> Get(int code);
        Task<List<ResponseServiceDTO>> SearchByName(string name);
    }
}

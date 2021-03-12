using PomoControl.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Service.Interfaces
{
    public interface IScopeService
    {
        Task<ResponseDTO> Create(ScopeDTO scopeDTO);
        Task<ResponseDTO> Update(ScopeDTO scopeDTO);
        Task Remove(int code);
        Task<ResponseDTO> Get(int code);
        Task<List<ResponseDTO>> SearchByName(string name);
    }
}

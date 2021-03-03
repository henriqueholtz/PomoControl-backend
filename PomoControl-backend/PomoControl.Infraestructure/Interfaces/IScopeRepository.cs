using PomoControl.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    public interface IScopeRepository : IBaseRepository<Scope>
    {
        Task<List<Scope>> SearchByName(string name);
    }
}

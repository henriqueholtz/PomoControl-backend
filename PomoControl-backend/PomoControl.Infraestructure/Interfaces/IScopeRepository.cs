using PomoControl.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Interfaces
{
    public interface IScopeRepository : IBaseRepository<Scope>
    {
        Task<Scope> SearchByName(string name);
    }
}

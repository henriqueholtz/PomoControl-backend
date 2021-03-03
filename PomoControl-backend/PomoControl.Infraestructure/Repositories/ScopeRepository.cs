using Microsoft.EntityFrameworkCore;
using PomoControl.Domain;
using PomoControl.Infraestructure.Context;
using PomoControl.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomoControl.Infraestructure.Repositories
{
    public class ScopeRepository : BaseRepository<Scope>, IScopeRepository
    {
        private readonly PomoContext _context;
        public ScopeRepository(PomoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Scope>> SearchByName(string name)
        {
            return await _context.Scopes.Where(x => x.Name.ToLower().Contains(name.ToLower())).AsNoTracking().ToListAsync();
        }
    }
}

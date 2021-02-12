using Microsoft.EntityFrameworkCore;
using PomoControll.Model;

namespace PomoControl.DAL.Data
{
    class PomoContext : DbContext
    {
        public PomoContext(DbContextOptions<PomoContext> options) : base(options)
        {

        }

        public DbSet<Scope> Scopes { get; set; }
        public DbSet<ScopeItem> ScopeItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PomoControl.DAL.ModelConfigurations;
using PomoControll.Model;

namespace PomoControl.DAL.Data
{
    public class PomoContext : DbContext
    {
        public PomoContext(DbContextOptions<PomoContext> options) : base(options)
        {

        }

        public DbSet<Scope> Scopes { get; set; }
        public DbSet<ScopeItem> ScopeItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApi -> ApplyConfiguration
            modelBuilder.ApplyConfiguration(new ScopeConfiguration());
            modelBuilder.ApplyConfiguration(new ScopeItemsConfiguration());
        }
    }
}

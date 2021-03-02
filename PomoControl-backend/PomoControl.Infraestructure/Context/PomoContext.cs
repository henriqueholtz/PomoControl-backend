using Microsoft.EntityFrameworkCore;
using PomoControl.Infraestructure.ModelConfigurations;
using PomoControl.Domain;
using System.Linq;

namespace PomoControl.Infraestructure.Context
{
    public class PomoContext : DbContext
    {
        public PomoContext(DbContextOptions<PomoContext> options) : base(options)
        {

        }

        public DbSet<Scope> Scopes { get; set; }
        public DbSet<ScopeItem> ScopeItems { get; set; }



        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));
                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType())
                        && !property.GetMaxLength().HasValue)
                    {
                        //property.SetMaxLength();
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //from assembly pega automaticamente todas classes que implementam IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PomoContext).Assembly);
            MapearPropriedadesEsquecidas(modelBuilder);


            //FluentApi -> ApplyConfiguration
            //modelBuilder.ApplyConfiguration(new ScopeConfiguration());
            //modelBuilder.ApplyConfiguration(new ScopeItemsConfiguration());
        }
    }
}

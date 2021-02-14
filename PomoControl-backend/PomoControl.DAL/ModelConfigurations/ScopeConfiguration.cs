using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.DAL.Data;
using PomoControl.DAL.Enums;
using PomoControll.Model;

namespace PomoControl.DAL.ModelConfigurations
{
    public class ScopeConfiguration : EntityConfiguration<Scope>, IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            //DefaultConfigs(builder, nameof(Scope));

        }
    }
}

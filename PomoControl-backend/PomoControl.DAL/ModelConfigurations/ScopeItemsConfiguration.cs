using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.DAL.Data;
using PomoControl.DAL.Enums;
using PomoControll.Model;

namespace PomoControl.DAL.ModelConfigurations
{
    class ScopeItemsConfiguration : EntityConfiguration<ScopeItem>, IEntityTypeConfiguration<ScopeItem>
    {
        public void Configure(EntityTypeBuilder<ScopeItem> builder)
        {
            DefaultConfigs(builder, nameof(Scope));

            builder.Property(p => p.Type)
                .HasColumnType(TypeName.BYTE)
                .ValueGeneratedNever(); //Remove Identity


            builder.Property(p => p.Commentary)
                .HasColumnType(TypeName.VARCHAR150)
                .ValueGeneratedNever(); //Remove Identity
        }
    }
}

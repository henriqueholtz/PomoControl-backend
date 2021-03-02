using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.Infraestructure.Data;
using PomoControl.Infraestructure.Enums;
using PomoControl.Domain;

namespace PomoControl.Infraestructure.ModelConfigurations
{
    public class ScopeItemsConfiguration : EntityConfiguration<ScopeItem>, IEntityTypeConfiguration<ScopeItem>
    {
        public void Configure(EntityTypeBuilder<ScopeItem> builder)
        {
            builder.ToTable("ScopeItems");
            builder.HasKey(prop => prop.Code);

            builder.Property(p => p.Start).IsRequired();
            //builder.Property(p => p.End)
            builder.Property(p => p.Type).HasColumnType(TypeName.TINYINT).IsRequired();
            builder.Property(p => p.Commentary).HasColumnType(TypeName.VARCHAR500);
        }
    }
}

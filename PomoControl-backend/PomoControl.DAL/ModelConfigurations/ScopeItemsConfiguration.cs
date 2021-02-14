using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.DAL.Data;
using PomoControl.DAL.Enums;
using PomoControll.Model;

namespace PomoControl.DAL.ModelConfigurations
{
    public class ScopeItemsConfiguration : EntityConfiguration<ScopeItem>, IEntityTypeConfiguration<ScopeItem>
    {
        public void Configure(EntityTypeBuilder<ScopeItem> builder)
        {
            builder.ToTable("ScopeItems");
            builder.HasKey(prop => prop.ScopeItemCode);

            builder.Property(p => p.Start).IsRequired();
            //builder.Property(p => p.End)
            builder.Property(p => p.Type).HasColumnType(TypeName.BYTE).IsRequired();
            builder.Property(p => p.Commentary).HasColumnType(TypeName.VARCHAR500);
        }
    }
}

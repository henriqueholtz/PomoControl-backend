using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomoControl.DAL.Data;
using PomoControl.DAL.Enums;
using PomoControll.Model;

namespace PomoControl.DAL.ModelConfigurations
{
    class ScopeConfiguration : EntityConfiguration<Scope>, IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            DefaultConfigs(builder, nameof(Scope));

            builder.Property(p => p.Name)
                .HasColumnType(TypeName.VARCHAR050)
                .ValueGeneratedNever(); //Remove Identity


            builder.Property(p => p.Description)
                .HasColumnType(TypeName.VARCHAR500)
                .ValueGeneratedNever(); //Remove Identity

            //builder.Property(p => p.)
            //    .HasColumnType(TypeName.VARCHAR500)
            //    .ValueGeneratedNever(); //Remove Identity
        }
    }
}

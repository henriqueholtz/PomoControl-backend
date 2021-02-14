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
            builder.ToTable("Scope");
            builder.HasKey(prop => prop.Code);
            builder.Property(p => p.Name).HasColumnType(TypeName.VARCHAR075).IsRequired();
            builder.Property(p => p.Description).HasColumnType(TypeName.VARCHAR500);
            //builder.Property(p => p.Steps)
            //builder.Property(p => p.WorkSeconds)
            //builder.Property(p => p.IntervalSeconds)
            //builder.Property(p => p.CreateDate)
            //builder.Property(p => p.StartDate)
            //builder.Property(p => p.UserCode)
            //builder.Property(p => p.Sunday)
            //builder.Property(p => p.Monday)
            //builder.Property(p => p.Tuesday)
            //builder.Property(p => p.Wednesday)
            //builder.Property(p => p.Thursday)
            //builder.Property(p => p.Friday)
            //builder.Property(p => p.Saturday)
            builder.HasMany(p => p.ScopeItems).WithOne(prop => prop.Scope).OnDelete(DeleteBehavior.Cascade);
            //builder.Property(p => p.ScopeItems)
        }
    }
}

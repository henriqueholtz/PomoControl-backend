using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomoControl.DAL.Data
{
    public class EntityConfiguration<TEntity> where TEntity : class
    {
        //defining default settings
        internal void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ToTable(tableName);
            builder.Property("Code").IsRequired().ValueGeneratedOnAdd();
            builder.HasKey("Code");

            //other examples
            //builder.Property(x => x.CreatedAt).IsRequired();
            //builder.Property("Code").HasDefaultValue();
        }
    }
}

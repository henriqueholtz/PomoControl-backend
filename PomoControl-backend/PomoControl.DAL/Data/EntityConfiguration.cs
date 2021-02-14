using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PomoControl.DAL.Data
{
    public class EntityConfiguration<TEntity> where TEntity : class
    {
        //defining default settings
        public void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ToTable(tableName);

            //other examples
            //builder.Property("Code").IsRequired().ValueGeneratedOnAdd();
            //builder.HasKey("Code");
            //builder.Property(x => x.CreatedAt).IsRequired();
            //builder.Property("Code").HasDefaultValue();
        }
    }
}

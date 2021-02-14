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
            //DefaultConfigs(builder, nameof(Scope));

            
        }
    }
}

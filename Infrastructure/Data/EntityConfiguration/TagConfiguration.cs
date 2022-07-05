using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infrastructure.Data.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.HasKey( x => x.TagId );
            builder.Property( x => x.Name );
            builder.HasMany( x => x.Recipes );
        }
    }
}

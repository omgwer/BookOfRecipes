using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Infrastructure.Data.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.HasKey( x => x.Id );
            builder.Property( x => x.Name );
            builder.Property( x => x.Index );
            builder.Property( x => x.RecipeId );
        }
    }
}

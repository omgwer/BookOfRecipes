using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure( EntityTypeBuilder<Recipe> builder )
        {
            /*builder.HasKey( t => t.RecipeId );
            builder.HasKey( t => t.AuthorId );
            builder.Property( t => t.Name ).HasMaxLength( 200 ).IsRequired();
            builder.Property( t => t.Description ).HasMaxLength( 200 ).IsRequired();*/
        }
    }
}

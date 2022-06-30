using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure( EntityTypeBuilder<Recipe> builder )
        {
            builder.HasKey( t => t.RecipeId );
            builder.Property( t => t.AuthorId );
            builder.Property( t => t.Name ).HasMaxLength( 200 ).IsRequired();
            builder.Property( t => t.Description ).IsRequired();
            builder.HasMany( t => t.TagsList );
            builder.Property( t => t.TimeForCook).IsRequired();
            builder.Property(t => t.NumberOfServings).IsRequired();            
            builder.HasMany( t => t.Ingredients );
            builder.HasMany( t => t.Steps );
            builder.Property(t => t.ImageUrl);            
        }
    }
}

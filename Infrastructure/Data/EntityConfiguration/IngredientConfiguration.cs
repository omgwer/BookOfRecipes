using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure( EntityTypeBuilder<Ingredient> builder )
        {
            builder.HasKey( x => x.Id );
            builder.Property( x => x.RecipeId );
            builder.Property( x => x.Order );
            builder.Property( x => x.Title );
            builder.Property( x => x.Description );
        }
    }
}

using Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    public class RecipeConfiguration : IEntityTypeConfiguration<RecipeDto>
    {
        public void Configure( EntityTypeBuilder<RecipeDto> builder )
        {
            builder.HasKey( t => t.RecipeId );
            builder.HasKey( t => t.AuthorId );
            builder.Property( t => t.Name ).HasMaxLength( 200 ).IsRequired();
            builder.Property( t => t.Description ).HasMaxLength( 200 ).IsRequired();
        }
    }
}

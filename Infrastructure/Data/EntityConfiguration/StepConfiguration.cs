using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityConfiguration
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure( EntityTypeBuilder<Step> builder )
        {           
            builder.HasKey( x => x.Id );
            builder.Property( x => x.RecipeId );            
            builder.Property( x => x.Index );            
            builder.Property( x => x.Description );            
        }
    }
}

using Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext( DbContextOptions options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new TagConfiguration() );
            modelBuilder.ApplyConfiguration( new IngredientConfiguration() );
            modelBuilder.ApplyConfiguration( new StepConfiguration() );
            modelBuilder.ApplyConfiguration( new RecipeConfiguration() );

            // для каждой таблицы добавлять в билдер конфиг.
        }
    }
}

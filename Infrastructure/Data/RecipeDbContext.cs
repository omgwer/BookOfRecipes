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
            modelBuilder.ApplyConfiguration( new RecipeConfiguration() );

            // для каждой таблицы добавлять в билдер конфиг.
        }
    }
}

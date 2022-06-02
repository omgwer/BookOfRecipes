﻿using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext( DbContextOptions options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new RecipeConfiguration() );
        }
    }
}

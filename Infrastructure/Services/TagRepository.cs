using Domain;
using Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class TagRepository : ITagRepository
    {
        private readonly DbSet<Tag> _dbSet;

        public TagRepository( RecipeDbContext dbContext )
        {
            _dbSet = dbContext.Set<Tag>();
        }

        public Tag? GetTag( string name )
        {
            return _dbSet.FirstOrDefault( e => e.Name == name );
        }
    }
}

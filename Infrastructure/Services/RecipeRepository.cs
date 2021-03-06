using Domain;
using Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbSet<Recipe> _dbSet;

        public RecipeRepository( RecipeDbContext dbContext )
        {
            _dbSet = dbContext.Set<Recipe>();
        }
        public Recipe Add( Recipe recipe )
        {
            _dbSet.Add( recipe );
            return recipe;
        }

        public String Delete( int id )
        {
            Recipe? recipe = _dbSet.Where( r => r.RecipeId == id ).FirstOrDefault();
            if ( recipe != null )
            {
                _dbSet.Remove( recipe );
                return "Success";
            }
            return "Fail";            
        }

        public Recipe? GetRecipe( int recipeId )
        {
            Recipe? recipe = _dbSet
                .Include( x => x.Ingredients )
                .Include( x => x.Steps )
                .Include( x => x.TagsList)
                .FirstOrDefault( x => x.RecipeId == recipeId );
            return recipe;
        }

        public List<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public Recipe Update( Recipe recipe )
        {
            _dbSet.Update( recipe );
            return recipe;
        }
    }
}

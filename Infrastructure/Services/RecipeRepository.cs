using Domain;
using Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _dbContext;
        private readonly DbSet<Recipe> _dbSet;
        private readonly DbSet<Ingredient> _dbIngredient;

        public RecipeRepository( RecipeDbContext dbContext )
        {
            _dbSet = dbContext.Set<Recipe>();
        }
        public Recipe Add( Recipe recipe )
        {
            _dbSet.Add( recipe );
            return recipe;
        }

        public void DeleteRecipe( int id )
        {
            throw new NotImplementedException();
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

        public int UpdateRecipe( Recipe recipe )
        {
            throw new NotImplementedException();
        }
    }
}

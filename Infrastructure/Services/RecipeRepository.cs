using Domain;
using Domain.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _dbContext;
        private readonly DbSet<Recipe> _test;

        public RecipeRepository( RecipeDbContext dbContext )
        {
            _test = dbContext.Set<Recipe>();
        }
        public Recipe CreateRecipe( Recipe recipe )
        {
            _test.Add( recipe );
            return recipe;
        }

        public void DeleteRecipe( int id )
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe( int id )
        {
            throw new NotImplementedException();
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

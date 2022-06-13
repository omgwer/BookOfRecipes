﻿using Domain;
using Domain.Services;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _dbContext;

        public RecipeRepository( RecipeDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public Recipe CreateRecipe( Recipe recipe )
        {
            var entity = _dbContext.Set<Recipe>().Add( recipe );
            return entity.Entity;
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

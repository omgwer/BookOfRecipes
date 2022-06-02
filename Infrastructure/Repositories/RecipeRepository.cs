using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public int CreateTodo( IRecipeDto recipe )
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe( int id )
        {
            throw new NotImplementedException();
        }

        public IRecipeDto GetRecipe( int id )
        {
            throw new NotImplementedException();
        }

        public List<IRecipeDto> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public int UpdateRecipe( IRecipeDto recipe )
        {
            throw new NotImplementedException();
        }
    }
}

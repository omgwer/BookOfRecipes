using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;

namespace Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        List<IRecipeDto> GetRecipes();
        IRecipeDto GetRecipe( int id );
        int CreateTodo( IRecipeDto recipe );
        void DeleteRecipe( int id);
        int UpdateRecipe( IRecipeDto recipe );
    }
}

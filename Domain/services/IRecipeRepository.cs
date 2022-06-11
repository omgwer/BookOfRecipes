
using Application.Models.Dto;

namespace Domain.Services
{
    public interface IRecipeRepository
    {
        List<RecipeDto> GetRecipes();
        RecipeDto GetRecipe( int id );
        int CreateTodo( RecipeDto recipe );
        void DeleteRecipe( int id );
        int UpdateRecipe( RecipeDto recipe );

        // описывает методы для работы с domain(хранилище рецептов)
    }
}

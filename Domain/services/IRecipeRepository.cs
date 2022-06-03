using Domain.Dto;

namespace Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        List<IRecipeDto> GetRecipes();
        IRecipeDto GetRecipe( int id );
        int CreateTodo( IRecipeDto recipe );
        void DeleteRecipe( int id );
        int UpdateRecipe( IRecipeDto recipe );

        // описывает методы для работы с domain(хранилище рецептов)
    }
}

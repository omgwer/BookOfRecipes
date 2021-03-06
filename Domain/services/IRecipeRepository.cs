using Domain;

namespace Domain.Services
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        Recipe? GetRecipe( int id );
        Recipe Add( Recipe recipe );
        String Delete( int id );
        Recipe Update( Recipe recipe );

        // описывает методы для работы с domain(хранилище рецептов)
    }
}

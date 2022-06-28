using Application.Models.Dto;
using Domain;

namespace Application.Services
{
    public interface IRecipeService
    {
        public RecipeDto SaveRecipe(RecipeDto recipe);

        public RecipeDto? GetRecipe(int recipeId);

        public void DeleteRecipe( int recipeId );

        public List<RecipeDto> GetRecipeList(int count);

        public Recipe? GetRecipeForUpdate( int recipeId );

        public RecipeDto SaveRecipe( Recipe recipe );
    }
}

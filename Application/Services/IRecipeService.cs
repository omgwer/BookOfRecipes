using Application.Models.Dto;
using Domain;

namespace Application.Services
{
    public interface IRecipeService
    {
        public RecipeDto SaveRecipe(RecipeDto recipe);

        public RecipeDto? GetRecipe(int recipeId);

        public String DeleteRecipe( int recipeId );

        public List<RecipeDto> GetRecipeList(int count);

    }
}

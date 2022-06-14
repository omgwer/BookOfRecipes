using Application.Models.Dto;

namespace Application.Services
{
    public interface IRecipeService
    {
        public RecipeDto SaveRecipe(RecipeDto recipe);

        public RecipeDto GetRecipe(int recipeId);

        public void DeleteRecipe( int recipeId );
    }
}

using Application.Models.Dto;

namespace Application.Services
{
    internal interface IRecipeService
    {
        public int SaveRecipe(RecipeDto recipe);

        public RecipeDto GetRecipe(int recipeId);

        public void DeleteRecipe( int recipeId );
    }
}

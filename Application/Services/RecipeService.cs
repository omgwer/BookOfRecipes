using Application.Models.Dto;
using Domain.Services;
using Application.Services;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService( IRecipeRepository recipeRepository )
        {
            _recipeRepository = recipeRepository;
        }

        public void DeleteRecipe( int recipeId )
        {
            throw new NotImplementedException();
        }

        public RecipeDto GetRecipe( int recipeId )
        {
            throw new NotImplementedException();
        }

        public int SaveRecipe( RecipeDto recipe )
        {
            int recipeId = 0;

            if ( recipe.AuthorId == 0 )
            {
                recipeId = _recipeRepository.CreateRecipe( recipe.ToRecipe() );
            }
            else 
            {
                recipeId = _recipeRepository.CreateRecipe( recipe.ToRecipe() );
            }



            return recipeId;
        }


        
        // слой бизнес логики, если id == 0  создается новый рецепт, если id != 0 обновляется
        // тут хранить метод toDto() Для удаления из обьекто полученных в базе данных, которые не нужны на фронте
    }
}



using Application.Models.Dto;
using Domain.Services;
using Domain;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService( IRecipeRepository recipeRepository, IUnitOfWork unitOfWork )
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public void DeleteRecipe( int recipeId )
        {
            throw new NotImplementedException();
        }

        public RecipeDto GetRecipe( int recipeId )
        {
            throw new NotImplementedException();
        }

        public RecipeDto SaveRecipe( RecipeDto recipe )
        {
            Recipe newRecipe = new Recipe();

            if ( recipe.RecipeId == 0 )
            {
                newRecipe = _recipeRepository.CreateRecipe( recipe.ToRecipe() );
            }
            else 
            {
                newRecipe = _recipeRepository.CreateRecipe( recipe.ToRecipe() );
            }

            _unitOfWork.Commit();

            return RecipeExtensions.toDto(newRecipe);
        }



        // слой бизнес логики, если id == 0  создается новый рецепт, если id != 0 обновляется
        // тут хранить метод toDto() Для удаления из обьекто полученных в базе данных, которые не нужны на фронте
    }
}



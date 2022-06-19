using Application.Models.Dto;
using Domain;
using Domain.Services;

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
            Recipe newRecipe;

            if ( recipe.RecipeId == 0 )
            { 
                newRecipe = _recipeRepository.CreateRecipe( recipe.ToRecipe() ); // rename to add
            }
            else
            {
                //TODO доделать обновление
                newRecipe = _recipeRepository.CreateRecipe( recipe.ToRecipe() ); 
            }

            _unitOfWork.Commit();

            return RecipeExtensions.toDto( newRecipe );
        }


        public List<RecipeDto> GetRecipeList( int count )
        {
            List<RecipeDto> list = new List<RecipeDto>();
            for ( int i = count * 4; i < count * 4 + 4; i++ )
            {
                Recipe? recipe = _recipeRepository.GetRecipe( i + 1 );
                if ( recipe != null )
                {
                    list.Add( RecipeExtensions.toDto( recipe ) );
                }
                else 
                { 
                    return list;
                }                
            }
            return list;
        }

        // слой бизнес логики, если id == 0  создается новый рецепт, если id != 0 обновляется
        // тут хранить метод toDto() Для удаления из обьекто полученных в базе данных, которые не нужны на фронте
    }
}



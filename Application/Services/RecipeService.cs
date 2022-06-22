using Application.Models.Dto;
using Domain;
using Domain.Services;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagListBuilder _tagListBuilder;

        public RecipeService( IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, ITagListBuilder tagListBuilder )
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
            _tagListBuilder = tagListBuilder;
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
                newRecipe = _recipeRepository.Add( recipe.ToRecipe( _tagListBuilder ) );
            }
            else
            {
                //TODO доделать обновление
                newRecipe = _recipeRepository.Add( recipe.ToRecipe( _tagListBuilder ) ); 
            }

            _unitOfWork.Commit();

            return RecipeExtensions.ToDto( newRecipe );
        }


        public List<RecipeDto> GetRecipeList( int count )
        {
            List<RecipeDto> list = new List<RecipeDto>();
            for ( int i = count * 4; i < count * 4 + 4; i++ )
            {
                Recipe? recipe = _recipeRepository.GetRecipe( i + 1 );
                if ( recipe != null )
                {
                    list.Add( RecipeExtensions.ToDto( recipe ) );
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



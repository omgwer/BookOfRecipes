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

        public String DeleteRecipe( int recipeId )
        {
            string result = _recipeRepository.Delete( recipeId );
            _unitOfWork.Commit();
            return result;
        }

        public RecipeDto? GetRecipe( int recipeId )
        {
            Recipe? recipe = _recipeRepository.GetRecipe( recipeId );
            if ( recipe != null )
            {
                return recipe.ToDto();
            }
            return null;
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
                var oldRecipe = _recipeRepository.GetRecipe( recipe.RecipeId );
                newRecipe = _recipeRepository.Update( recipe.ToRecipe( _tagListBuilder, oldRecipe ) );
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
                    continue;
                }
            }
            return list;
        }
    }
}



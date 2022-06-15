using Application.Models.Dto;
using Domain;

namespace Application.Services
{
    public static class RecipeExtensions
    {
        public static RecipeDto toDto(this Recipe recipe )
        {
            RecipeDto recipeDto = new RecipeDto
            {
                RecipeId = recipe.RecipeId,
                AuthorId = recipe.AuthorId,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Ingredients = GetIngredientsDtoList( recipe.Ingredients ),
                Name = recipe.Name,
                NumberOfServings = recipe.NumberOfServings,
                Steps = GetStepsDtoList( recipe.Steps ),
                TimeForCook = recipe.TimeForCook,
                TagsList = GetTagsDtoList( recipe.TagsList ),
            };
            return recipeDto;
        }

        private static List<IngredientDto> GetIngredientsDtoList( List<Ingredient> list )
        {
            var listDto = new List<IngredientDto>();
            foreach ( var item in list )
            {
                listDto.Add( ToIngredientDto( item ) );
            }
            return listDto;
        }

        private static List<StepDto> GetStepsDtoList( List<Step> list )
        {
            var listDto = new List<StepDto>();
            foreach ( var item in list )
            {
                listDto.Add( ToStepDto( item ) );
            }
            return listDto;
        }

        private static string GetTagsDtoList( List<Tag> tagsList )
        {
            string tagsDto = " ";
            foreach ( var tag in tagsList )
            {
                tagsDto += tag.Name + ", ";
            }

            return tagsDto[ 0..^2 ];
        }

        private static IngredientDto ToIngredientDto(Ingredient ingredient)
        {
            return new IngredientDto
            {
                Description = ingredient.Description,
                Order = ingredient.Order,
                Title = ingredient.Title,
            };
        }

        private static StepDto ToStepDto( Step step )
        {
            return new StepDto { 
             Description = step.Description,
             Order = step.Order,             
            };
        }
    }
}

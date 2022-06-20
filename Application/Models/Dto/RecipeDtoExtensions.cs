using Domain;

namespace Application.Models.Dto
{
    public static class RecipeDtoExtensions
    {
        public static Recipe ToRecipe( this RecipeDto dto )
        {
            return new Recipe
            {
                RecipeId = dto.RecipeId,
                AuthorId = dto.AuthorId,
                Name = dto.Name,
                Description = dto.Description,
                TimeForCook = dto.TimeForCook,
                NumberOfServings = dto.NumberOfServings,
                ImageUrl = dto.ImageUrl,
                Ingredients = GetIngredientsList( dto.Ingredients ),
                TagsList = GetTagsList( dto.TagsList ) ,
                Steps = GetStepsList(dto.Steps)
            };
        }

        private static List<Tag> GetTagsList( List<TagDto> listDto)
        {
            var list = new List<Tag>();
            foreach ( var item in listDto )
            {
                list.Add( item.ToTag( item ) );
            }
            return list;
        }

        private static List<Ingredient> GetIngredientsList( List<IngredientDto> listDto )
        {
            var list = new List<Ingredient>();
            foreach ( var item in listDto )
            {
                list.Add( item.ToIngredient( item ) );
            }
            return list;
        }

        private static List<Step> GetStepsList( List<StepDto> listDto )
        {
            var list = new List<Step>();
            foreach ( var item in listDto )
            {
                list.Add( item.ToStep( item ) );
            }
            return list;
        }       
    }
}

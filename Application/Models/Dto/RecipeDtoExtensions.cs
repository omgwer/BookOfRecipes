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
                TagsList = GetTagsList( dto.TagsList ),
                TimeForCook = dto.TimeForCook,
                NumberOfServings = dto.NumberOfServings,
                ImageUrl = dto.ImageUrl,
                Ingredients = GetIngredientsList( dto.Ingredients ),
                Steps = GetStepsList(dto.Steps)
            };
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

        private static List<Tag> GetTagsList( string tags )
        {
            var list = new List<Tag>();
            string tag = tags.Replace( ",", " " ).Replace(".", " ");
            tag.Replace( "  ", " " );            
            var tagsList = tag.Split( " " );            
            foreach ( var item in tagsList ) 
            {
                var test = item.Trim();
                if ( test != "" )
                {
                    list.Add( new Tag
                    {
                        Id = 0,
                        Name = item.Trim(),
                    } );
                }                               
            }
            return list;
        }
    }
}

using System.Diagnostics;
using Application.Services;
using Domain;

namespace Application.Models.Dto
{
    public static class RecipeDtoExtensions
    {
        public static Recipe ToRecipe( this RecipeDto dto, ITagListBuilder tagListBuilder )
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
                TagsList = tagListBuilder.Build( dto.TagsList ) ,
                Steps = GetStepsList(dto.Steps)
            };
        }

        public static Recipe ToRecipe( this RecipeDto dto, ITagListBuilder tagListBuilder, Recipe recipe )
        {
            recipe.AuthorId = dto.AuthorId;
            recipe.Name = dto.Name;
            recipe.Description = dto.Description;
            recipe.TimeForCook = dto.TimeForCook;
            recipe.NumberOfServings = dto.NumberOfServings;
            recipe.ImageUrl = dto.ImageUrl;
            recipe.Ingredients = GetIngredientsList( dto.Ingredients );
            recipe.TagsList = tagListBuilder.Build( dto.TagsList );
            recipe.Steps = GetStepsList( dto.Steps );
            return recipe;
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

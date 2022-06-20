using Domain;

namespace Application.Models.Dto
{
    public class IngredientDto
    {
        public int Index { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Ingredient ToIngredient(IngredientDto dto )
        {
            return new Ingredient
            {
                Id = 0,
                RecipeId = 0,
                Index = dto.Index,
                Title = dto.Title,
                Description = dto.Description,
            };
        }
    }
}

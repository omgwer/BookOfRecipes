
namespace Application.Models.Dto
{
    public class RecipeDto
    {
        public int AuthorId { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<TagDto> TagsList { get; set; } = new List<TagDto>();
        public int TimeForCook { get; set; }
        public int NumberOfServings { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
        public List<StepDto> Steps { get; set; } = new List<StepDto>();
        public string ImageUrl { get; set; } = string.Empty;
        
    }
}

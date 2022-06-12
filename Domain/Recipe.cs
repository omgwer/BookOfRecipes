
namespace Domain
{
    // заполнить данными как в базе
    public class Recipe
    {  
        public int RecipeId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Tag> TagsList { get; set; } = new List<Tag>();
        public int TimeForCook { get; set; }
        public int NumberOfServings { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public List<Step> Steps { get; set; } = new List<Step>();
        public string ImageUrl { get; set; } = string.Empty;  
    }
}

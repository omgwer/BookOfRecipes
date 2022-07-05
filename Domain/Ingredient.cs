

namespace Domain
{
    public class Ingredient
    {
        public int Id { get; set; } // dbContext
        public int RecipeId { get; set; }  //dbContext
        public int Index { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

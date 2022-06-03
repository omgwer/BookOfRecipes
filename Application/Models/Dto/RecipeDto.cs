namespace Domain.Dto
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

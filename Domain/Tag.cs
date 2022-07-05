
namespace Domain
{
    public class Tag
    {
        public int TagId { get; set; } //dbContext
        public string Name { get; set; } = string.Empty;

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
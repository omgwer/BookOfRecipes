using Domain;

namespace Application.Models.Dto
{
    public class TagDto
    {
        //public int Id { get; set; }  //dbContext
        public string Name { get; set; } = string.Empty;
        public int Index { get; set; }

        public Tag ToTag( TagDto Dto ) {
            return new Tag
            {
                Index = Dto.Index,
                Name = Dto.Name,
                Id = 0,
                RecipeId = 0
            };
        }
    }
}

using Domain;

namespace Application.Models.Dto
{
    public class StepDto
    {
        public int Order { get; set; }
        public string Description { get; set; } = string.Empty; 

        /*
         * Передаем нули, в случае, если рецепт новый.
         */
        public Step ToStep( StepDto dto )
        {
            return new Step
            {
                Order = dto.Order,
                Description = dto.Description,
                Id = 0,  
                RecipeId = 0
            };
        }
    }
}

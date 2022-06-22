using Domain;

namespace Application.Models.Dto
{
    public class TagDto
    {
        //public int Id { get; set; }  //dbContext
        public string Name { get; set; } = string.Empty;        

        public Tag ToTag( TagDto Dto ) {

            return new Tag
            {
                Name = Dto.Name,
               // TagId = 0                
            };
        }
    }
}

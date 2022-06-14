using Application.Models.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController( IRecipeService recipeService )
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        [Route( "save" )]
        public IActionResult SaveRecipe( [FromBody] RecipeDto recipe )
        {
            RecipeDto newRecipe = _recipeService.SaveRecipe( recipe );
           /* if ( recipeId == 0 )
            {
                return BadRequest( "Recipe dont save!!!" );

            }*/
                       
            return Ok(newRecipe);
        }

    }
}

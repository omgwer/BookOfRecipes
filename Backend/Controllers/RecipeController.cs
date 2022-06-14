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

            if ( recipe.RecipeId == 0 )
            {
                return BadRequest("Recipe dont save!");
            }

            return Ok(newRecipe);
        }

        [HttpGet]
        [Route( "list/{count}" )]
        public IActionResult GetRecipeList( int count )
        {
            List<RecipeDto> recipeList = _recipeService.GetRecipeList(count);

            if ( recipeList.Count == 0 )
            {
                return NotFound();
            }
                
            return Ok( recipeList );
        }
    }    
}

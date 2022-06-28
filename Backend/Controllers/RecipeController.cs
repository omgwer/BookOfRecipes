using Application.Models.Dto;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IPhotoService _photoService;

        public RecipeController( IRecipeService recipeService, IPhotoService photoService )
        {
            _recipeService = recipeService;
            _photoService = photoService;
        }

        [HttpPost]
        [Route( "save" )]
        public IActionResult SaveRecipe( [FromBody] RecipeDto recipe )
        {
            RecipeDto newRecipe = _recipeService.SaveRecipe( recipe );

            if ( newRecipe.RecipeId == 0 )
            {
                return BadRequest( "Recipe dont save!" );
            }

            return Ok( newRecipe );
        }

        [HttpGet]
        [Route( "list/{count}" )]
        public IActionResult GetRecipeList( int count )
        {
            List<RecipeDto> recipeList = _recipeService.GetRecipeList( count );

            if ( recipeList.Count == 0 )
            {
                return NotFound();
            }

            return Ok( recipeList );
        }

        [HttpPost]
        [Route( "{recipeId}/updatePhoto" )]
        public IActionResult UpdatePhoto( IFormFile file, int recipeId )
        {
            Recipe? recipe = _recipeService.GetRecipeForUpdate( recipeId );
            if ( recipe == null )
            {
                return BadRequest( "Recipe not found!" );
            }

            string photoPath = _photoService.savePhoto( file, recipeId );

            recipe.ImageUrl = photoPath;

            RecipeDto newRecipe = _recipeService.SaveRecipe( recipe );

            return Ok( "photo saved" );
        }
    }
}

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
        private readonly int sleepTime = 1000;

        public RecipeController( IRecipeService recipeService, IPhotoService photoService )
        {
            _recipeService = recipeService;
            _photoService = photoService;
        }

        [HttpPost]
        [Route( "save" )]
        public IActionResult SaveRecipe( [FromBody] RecipeDto recipe )
        {
            Thread.Sleep( sleepTime );
            RecipeDto newRecipe = _recipeService.SaveRecipe( recipe );

            if ( newRecipe.RecipeId == 0 )
            {
                return BadRequest( "Recipe dont save!" );
            }

            return Ok( newRecipe );
        }

        [HttpGet]
        [Route( "{recipeId}" )]
        public IActionResult GetRecipe( int recipeId )
        {
            Thread.Sleep( 300 );
            RecipeDto? recipe = _recipeService.GetRecipe( recipeId );
            if ( recipe == null )
            {
                return BadRequest( "Recipe not found!" );
            }

            return Ok( recipe );
        }

        [HttpDelete]
        [Route( "{recipeId}/delete" )]
        public IActionResult DeleteRecipe( int recipeId )
        {
            Thread.Sleep( sleepTime );
            String result =_recipeService.DeleteRecipe( recipeId );
            if ( result == "Fail" )
            {
                return BadRequest( "Recipe not found!" );
            }

            return Ok( "{\"response\" : \"" + result + "\"}" );
        }

        [HttpGet]
        [Route( "list/{count}" )]
        public IActionResult GetRecipeList( int count )
        {
            Thread.Sleep( sleepTime );
            List<RecipeDto> recipeList = _recipeService.GetRecipeList( count );

            if ( recipeList.Count == 0 )
            {
                return NotFound( recipeList );
            }

            return Ok( recipeList );
        }

        [HttpPost]
        [Route( "{recipeId}/updatePhoto" )]
        public IActionResult UpdatePhoto( IFormFile file, int recipeId )
        {
            Thread.Sleep( sleepTime );
            RecipeDto? recipe = _recipeService.GetRecipe( recipeId );
            if ( recipe == null )
            {
                return BadRequest( "Recipe not found!" );
            }

            string photoPath = _photoService.savePhoto( file, recipeId );

            recipe.ImageUrl = photoPath;

            RecipeDto newRecipe = _recipeService.SaveRecipe( recipe );

            return Ok( newRecipe );
        }
    }
}

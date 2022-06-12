using Application.Models.Dto;
using Application.Services;
using Domain.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route( "api/[controller]" )]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeController( IRecipeRepository todoRepository, IUnitOfWork unitOfWork )
        {
            _recipeRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route( "save" )]
        public IActionResult SaveRecipe( [FromBody] RecipeDto recipe )
        {
            var recipeId = new RecipeService( _recipeRepository ).SaveRecipe( recipe );
           /* if ( recipeId == 0 )
            {
                return BadRequest( "Recipe dont save!!!" );

            }*/

            _unitOfWork.Commit();
            return Ok( recipeId );
        }

    }
}

using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route( "api/[controller]" )]
    public class CreateRecipeController : ControllerBase
    {
        private readonly IRecipeRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRecipeController( IRecipeRepository todoRepository, IUnitOfWork unitOfWork )
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route( "test" )]
        public IActionResult GetAllTodos()
        {
            return Ok( "testResponse" );
        }


    }
}

using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IPhotoService
    {
        string savePhoto( IFormFile file, int recipeId );
    }
}

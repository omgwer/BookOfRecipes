using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IHostingEnvironment _appEnvironment;
        /*private string _path = "Frontend/ClientApp/src/assets/shared-data/";*/

        public PhotoService( IHostingEnvironment appEnvironment )
        {
            _appEnvironment = appEnvironment;
        }

        public string savePhoto( IFormFile file, int recipeId )
        {
            var filePath = "\\Data\\" + recipeId.ToString() + "\\" + file.FileName;
            var backendFilePath = _appEnvironment.WebRootPath + filePath;
            string? directory = Path.GetDirectoryName( backendFilePath );

            if ( !Directory.Exists( directory ) )
            {
                Directory.CreateDirectory( directory );
            }

            using ( var fileStream = new FileStream( backendFilePath, FileMode.Create ) )
            {
                file.CopyTo( fileStream );
                fileStream.Close();
            }

            return filePath;
        }
    }
}

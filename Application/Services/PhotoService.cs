using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private string _path = "Frontend/ClientApp/src/assets/shared-data/";

        public PhotoService( IHostingEnvironment appEnvironment )
        {
            _appEnvironment = appEnvironment;
        }

        public string savePhoto( IFormFile file, int recipeId )
        {
            var filePath = _appEnvironment.ContentRootPath.Replace( "Backend\\", "" ) + _path + recipeId.ToString() + "\\" + file.FileName;
            string? directory = Path.GetDirectoryName( filePath );

            if ( !Directory.Exists( directory ) )
            {
                Directory.CreateDirectory( directory );
            }

            using ( var fileStream = new FileStream( filePath, FileMode.Create ) )
            {
                file.CopyTo( fileStream );
                fileStream.Close();
            }            

            filePath = "../../../assets/shared-data/" + recipeId.ToString() + "/" + file.FileName;
            return filePath;
        }
    }
}

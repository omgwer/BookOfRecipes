using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder( args );
var app = builder.Build();

/*app.AddSpaStaticFiles( configuration =>
{
    configuration.RootPath = "ClientApp/dist";
} );*/

app.UseDeveloperExceptionPage();
          
app.UseStaticFiles();          

app.UseSpa( spa =>
{
    spa.Options.SourcePath = "ClientApp";
    spa.UseAngularCliServer( npmScript: "start" );                
} );
 
app.Run();
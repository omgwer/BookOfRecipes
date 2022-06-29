/*var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

using Application.Services;
using Domain;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddCors( options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins( "http://localhost:4200" )
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        } );
} );

// Add services to the container.

builder.Services.AddDbContext<RecipeDbContext>( t =>
{
    t.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ), b => b.MigrationsAssembly("Backend") );
} );

builder.Services.AddControllers().AddJsonOptions( options => options.JsonSerializerOptions.IncludeFields = true );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Тут добавить сервис IToDoService в DI
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ITagListBuilder, TagListBuilder>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
/*app.UseDirectoryBrowser();*/
app.MapControllers();

app.UseCors( builder =>
{
    builder
    .WithOrigins( "localhost:4200" )
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
} );

app.Run();

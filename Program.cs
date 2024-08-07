using Book.Data;
using Microsoft.EntityFrameworkCore;
using Book.Services;
using Book.Repository;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowSpecificOrigin",
           builder => builder.WithOrigins("http://127.0.0.1:5502")
                             .AllowAnyMethod()
                             .AllowAnyHeader());
   });

builder.Services.AddControllers();


// Configurazione dei servizi e del serializzatore JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
builder.Services.AddTransient<IPublisherService, PublisherService>();

var app = builder.Build();

// Configura il middleware dell'applicazione
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });

            

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Abilita la politica CORS
app.MapControllers();


app.Run();
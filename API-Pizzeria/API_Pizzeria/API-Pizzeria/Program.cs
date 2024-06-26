

using App.Services;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;//Para que aceda al contexto. 
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    /*
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//Se crea la base de datos
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
builder.Configuration["ConnectionStrings:StockPizzaDBConnectionString"], b => b.MigrationsAssembly("Infrastructure")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserProductRepository, UserProductRepository>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<UserServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

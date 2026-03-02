using api;
using api.Controllers;
using Microsoft.EntityFrameworkCore;
using src.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//builder.Services.AddSingleton<BookRepo>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookRepo>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<MemberService2>();
builder.Services.AddScoped<MemberRepo>();
builder.Services.AddScoped<MemberRepo2>();



var app = builder.Build();

// Migrate/create database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.MapControllers();

app.Run();
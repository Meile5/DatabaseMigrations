using api.Controllers;
using src;



var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<BookRepo>();
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookRepo>();



var app = builder.Build();

app.Run();


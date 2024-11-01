using System.Text.Json.Serialization;
using Test_Api_NumberBook.Data;
using Test_Api_NumberBook.Repositories;
using Test_Api_NumberBook.Services;
using Microsoft.EntityFrameworkCore;
using Test_Api_NumberBook.Models;

var builder = WebApplication.CreateBuilder(args);

// –егистраци€ репозитори€ и сервиса дл€ внедрени€ зависимостей / Registering repository and service for dependency injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

// »спользование in-memory базы данных дл€ хранени€ контактов / Configuring in-memory database for contacts storage
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseInMemoryDatabase("ContactsDb"));

builder.Services.AddControllers().AddNewtonsoftJson(); 


var app = builder.Build();

app.MapGet("/", (HttpContext http) =>
{
    http.Response.Redirect("/api/contacts", permanent: false);
    return Task.CompletedTask;
});

// Ќастраиваем HTTP-канал
app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();
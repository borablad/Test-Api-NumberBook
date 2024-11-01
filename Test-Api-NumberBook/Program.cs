using System.Text.Json.Serialization;
using Test_Api_NumberBook.Data;
using Test_Api_NumberBook.Repositories;
using Test_Api_NumberBook.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  онфигураци€ параметров сериализации JSON / Configuring JSON serialization options
//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});

// –егистраци€ репозитори€ и сервиса дл€ внедрени€ зависимостей / Registering repository and service for dependency injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

// »спользование in-memory базы данных дл€ хранени€ контактов / Configuring in-memory database for contacts storage
builder.Services.AddDbContext<ContactContext>(options => options.UseInMemoryDatabase("ContactsDb"));

var app = builder.Build();


app.Run();
 


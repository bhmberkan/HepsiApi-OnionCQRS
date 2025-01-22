using HepsiApi.PresisTence; // referans eklemeyý unuttuðum için tanýmlamýyormuþ
// api kýsmýnda referances kýsmýnda persistence kýsmýný seçtim düzeldi

using Hepsiapi.Application;
using HepsiApi.Mapper;
using Hepsiapi.Application.Exeptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;




builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


// bu kodu yukarýdakinin altýna yazmamýn sebebi öncelikle hangi ortama ait olduðunu bulup ondan sonra configuration yapmasý
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(); // bu derste ekledik applicationumuzu çalýþtýrmak için
// IServiceCollection gibi çalýþtý proje referansý vermedýk.
builder.Services.AddCustomMapper();

 var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandLingMiddleware(); // 

app.UseAuthorization();

app.MapControllers();

app.Run();

//23.20 de kaldým ders 11
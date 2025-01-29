using HepsiApi.PresisTence; // referans eklemey� unuttu�um i�in tan�mlam�yormu�
// api k�sm�nda referances k�sm�nda persistence k�sm�n� se�tim d�zeldi

using Hepsiapi.Application;
using HepsiApi.Infrastructure;
using HepsiApi.Mapper;
using Hepsiapi.Application.Exeptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>();

var env = builder.Environment;




builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


// bu kodu yukar�dakinin alt�na yazmam�n sebebi �ncelikle hangi ortama ait oldu�unu bulup ondan sonra configuration yapmas�
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration); 

builder.Services.AddApplication(); // bu derste ekledik applicationumuzu �al��t�rmak i�in
// IServiceCollection gibi �al��t� proje referans� vermed�k.
builder.Services.AddCustomMapper();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hepsi Api", Version = "v1", Description = "Hepsi Api Swagger Client" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {  
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In= ParameterLocation.Header,
        Description = "'Bearer' Yaz�p bo�luk b�rakt�ktan sonra Token'� girebilirsiniz \r\n\r\n �rne�in: \"Bearer eyJhbGciOiJIU<I1NiIsInR5cCI6kpXVCJ9\""

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});








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

//23.20 de kald�m ders 11
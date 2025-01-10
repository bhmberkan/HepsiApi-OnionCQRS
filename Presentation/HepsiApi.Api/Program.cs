using HepsiApi.PresisTence; // referans eklemey� unuttu�um i�in tan�mlam�yormu�
// api k�sm�nda referances k�sm�nda persistence k�sm�n� se�tim d�zeldi

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


// bu kodu yukar�dakinin alt�na yazmam�n sebebi �ncelikle hangi ortama ait oldu�unu bulup ondan sonra configuration yapmas�
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

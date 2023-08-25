using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adicionar o serviço de controllers
builder.Services.AddControllers();

//adicona o gerador de swagger 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = " API para genrenciar filmes e seus generos - introdução a sprint 2 - backend API",

        Contact = new OpenApiContact
        {
            Name = "Senai informatica - Mateus Paladino",
            Url = new Uri("https://github.com/MateusPaladino-29"),
          
        },
      
    });

    ///Configure o Swagger para usar o arquivo XML gerado com as instruções anteriores. 
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//mapear os controles
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();


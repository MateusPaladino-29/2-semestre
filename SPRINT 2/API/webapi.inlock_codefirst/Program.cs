using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valida quem esta solicitando pelo validation 
            ValidateIssuer = true,

            //valida quem esta recebendo 
            ValidateAudience = true,

            //Define se o tempo de expiraçao do tokem sera validado 
            ValidateLifetime = true,

            //forma de criptografia e ainda validação da chave de autendicaçao
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiração do token 
            ClockSkew = TimeSpan.FromMinutes(5),

            //De onde esta vindo(issuer)
            ValidIssuer = "webapi.filmes.tarde",

            //para onde esta indo(Audience)
            ValidAudience = "webapi.filmes.tarde"

        };
    });

builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "API Filmes",
    Description = "API para gerenciamento de fimes - Introdução a sprint 2 - Backend API",
    Contact = new OpenApiContact
    {
        Name = "Mateus Paladino - Desenvolvedor",
        Url = new Uri("https://github.com/MateusPaladino-29")
    }
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseHttpsRedirection();

app.UseAuthentication();
        
app.UseAuthorization();

app.MapControllers();

app.Run();

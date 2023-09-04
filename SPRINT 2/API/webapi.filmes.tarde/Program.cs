using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de controllers
builder.Services.AddControllers();

//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os par�metros de valida��o do token
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
    //valida quem esta solicitando pelo validation 
    ValidateIssuer = true,

    //valida quem esta recebendo 
    ValidateAudience = true,

    //Define se o tempo de expira�ao do tokem sera validado 
    ValidateLifetime = true,

    //forma de criptografia e ainda valida��o da chave de autendica�ao
    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

    //valida o tempo de expira��o do token 
    ClockSkew = TimeSpan.FromMinutes(5),

    //De onde esta vindo(issuer)
    ValidIssuer = "webapi.filmes.tarde",

    //para onde esta indo(Audience)
    ValidAudience = "webapi.filmes.tarde"

};
});//paramos aqui....continuar na segunda

//Adiciona o gerador do Swagger 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de fimes - Introdu��o a sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Mateus Paladino - Desenvolvedor",
            Url = new Uri("https://github.com/MateusPaladino-29")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Poder entrar no ambiente ou nao 
app.UseAuthentication();

//REalixar uma a�ao que tem retris��o de acesso
app.UseAuthorization();
//Mapear os controllers
app.MapControllers();

app.Run();
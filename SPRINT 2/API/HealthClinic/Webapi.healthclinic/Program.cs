using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using webapi.health.clinic.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

            //Define se o tempo de expira�ao do tokem sera validado 
            ValidateLifetime = true,

            //forma de criptografia e ainda valida��o da chave de autendica�ao
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-chave-autenticacao-webapi-dev")),

            //valida o tempo de expira��o do token 
            ClockSkew = TimeSpan.FromMinutes(5),

            //De onde esta vindo(issuer)
            ValidIssuer = "health.clinic-webapi",

            //para onde esta indo(Audience)
            ValidAudience = "health.clinic-webapi"

        };
    });



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
});



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Event+ Tarde",
        Description = " API do projeto Health Clinic",

        Contact = new OpenApiContact
        {
            Name = "Senai informatica - Mateus Paladino",
            Url = new Uri("https://github.com/MateusPaladino-29"),

        },

    });



    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
        new string[]{}

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
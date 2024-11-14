using System.Text;
using BookStore.App.Modules.User;
using BookStore.Config;
using BookStore.Data;
using BookStore.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
 swagger.OperationFilter<SwaggerDefaultValues>();

 swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
 {
  Name = "Authorization",
  In = ParameterLocation.Header,
  Type = SecuritySchemeType.ApiKey,
  Scheme = "Bearer"
 });

 swagger.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });


});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
{
 options.AddPolicy(name: "MyPolicy",
     policy =>
     {
      policy.WithOrigins("http://localhost:8080")
         .AllowAnyHeader()
         .AllowAnyMethod();
     });
});

var key = Encoding.ASCII.GetBytes(Key.SecretKey);

builder.Services.AddAuthentication(jwt =>
{
 jwt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
 jwt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(define =>
{
 define.RequireHttpsMetadata = false;
 define.SaveToken = true;
 define.TokenValidationParameters = new TokenValidationParameters
 {
  ValidateIssuerSigningKey = true,
  IssuerSigningKey = new SymmetricSecurityKey(key),
  ValidateIssuer = false,
  ValidateAudience = false
 };
});


builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



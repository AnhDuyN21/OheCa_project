using Application.Commons;
using EXE_02;
using Infrastructures;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(option => option.AddPolicy("oheca", build =>
{
    build.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));
var configuration = builder.Configuration.Get<AppConfiguration>() ?? new AppConfiguration();
builder.Services.AddInfrastructuresService(configuration.DatabaseConnection);
builder.Services.AddWebAPIService();
builder.Services.AddSingleton(configuration);


// Load JWT settings from configuration
var jwtSettings = builder.Configuration.GetSection("JWTSection").Get<JWTSection>();
var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy =>
        policy.RequireClaim("RoleID", "1"));
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim("RoleID", "2"));
    options.AddPolicy("Staff", policy =>
        policy.RequireClaim("RoleID", "3"));
});
builder.Services.AddSwaggerGen(setup =>
{
// Include 'SecurityScheme' to use JWT Authentication
var jwtSecurityScheme = new OpenApiSecurityScheme
{
BearerFormat = "JWT",
Name = "JWT Authentication",
In = ParameterLocation.Header,
Type = SecuritySchemeType.Http,
Scheme = JwtBearerDefaults.AuthenticationScheme,
Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

Reference = new OpenApiReference
{
Id = JwtBearerDefaults.AuthenticationScheme,
Type = ReferenceType.SecurityScheme
}
};
   
setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
//setup.MapType<IFormFile>(() => new OpenApiSchema {  Type = "string", Format = "json" });
});

/*
    register with singleton life time
    now we can use dependency injection for AppConfiguratio
*/
builder.Services.AddSingleton(configuration);
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\exe02-oheca-firebase-adminsdk-htvjl-97f30ef8b4.json");


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.UseMiddleware<ConfirmationTokenMiddleware>();
app.MapHealthChecks("/healthchecks");
app.UseHttpsRedirection();

// todo authentication
app.UseAuthentication();
app.UseCors("oheca");
app.UseAuthorization();


app.MapControllers();

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program { }
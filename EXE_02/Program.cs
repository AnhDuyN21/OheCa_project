using Application.Commons;
using EXE_02;
using EXE_02.Validations.AddressToShipValidations;
using EXE_02.Validations.FeedBackValidations;
using EXE_02.Validations.OrderDetailValidations;
using EXE_02.Validations.OrderValidations;
using EXE_02.Validations.PaymentValidations;
using EXE_02.Validations.ShipCompanyValidations;
using EXE_02.Validations.ShipperValidations;
using EXE_02.Validations.VoucherValidations;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.OAuth2;
using Infrastructures;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Net.payOS;
using Newtonsoft.Json.Linq;
using System.Text;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(option => option.AddPolicy("oheca", build =>
{
    build.WithOrigins("https://ohecaproject-gduycats-projects.vercel.app").AllowAnyMethod().AllowAnyHeader();
}));
var configuration = builder.Configuration.Get<AppConfiguration>() ?? new AppConfiguration();
builder.Services.AddInfrastructuresService(configuration.DatabaseConnection);
builder.Services.AddWebAPIService();
builder.Services.AddSingleton(configuration);
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ShipCompanyCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ShipCompanyUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ShipperCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ShipperUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<VoucherCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<VoucherUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PaymentCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PaymentUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderDetailCreateDTOValidatio>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderDetailUpdateDTOValidatio>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FeedBackCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FeedBackUpdateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressToShipCreateDTOValidation>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddressToShipUpdateDTOValidation>());

//PayOS
PayOS payOs = new PayOS(configuration.PayOSConfig.PAYOS_CLIENT_ID,
                        configuration.PayOSConfig.PAYOS_API_KEY,
                        configuration.PayOSConfig.PAYOS_CHECKSUM_KEY);
builder.Services.AddSingleton(payOs);
//End PayOS

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

//Firebase
var google = JObject.FromObject(configuration.GoogleImage);
string g = google.ToString();
string temp = Path.GetTempFileName();
File.WriteAllText(temp, g);
Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", temp);
GoogleCredential credential = GoogleCredential.FromFile(temp);
//End FireBase

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
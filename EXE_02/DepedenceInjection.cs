
using Application;
using Application.Interfaces;
using Application.ViewModels.UserDTO;
using EXE_02.Services;
using EXE_02.Validations.UserValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructures;
using System.Diagnostics;
using WebAPI.Middlewares;


namespace EXE_02
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClaimsService, ClaimsService>();
            //Fluent Validator
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            //Fluent Validator / User
            services.AddTransient<IValidator<CreateUserDTO>, CreateAccountViewModelValidation>();
            services.AddTransient<IValidator<RegisterUserDTO>, RegisterAccountViewModelValidation>();
            return services;
        }
    }

}


using Application.Interfaces;
using EXE_02.Services;
using System.Diagnostics;


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
            //services.AddSingleton<GlobalExceptionMiddleware>();
            //services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            //services.AddFluentValidationAutoValidation();
            //services.AddFluentValidationClientsideAdapters();
            return services;
        }
    }

}

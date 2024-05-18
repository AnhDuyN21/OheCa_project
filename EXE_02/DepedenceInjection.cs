
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
            
            services.AddHttpContextAccessor();
            //services.AddFluentValidationAutoValidation();
            //services.AddFluentValidationClientsideAdapters();
            return services;
        }
    }

}

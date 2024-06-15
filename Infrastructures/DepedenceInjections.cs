using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures
{
    public static class DepedenceInjections
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            
            //DanhDev
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IShipCompanyService, ShipCompanyService>();
            services.AddScoped<IShipCompanyRepository, ShipCompanyRepository>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<IAddressToShipService, AddressToShipService>();
            services.AddScoped<IAddressToShipRepository, AddressToShipRepository>();
            services.AddScoped<IAddressUserService, AddressUserService>();
            services.AddScoped<IAddressUserRepository, AddressUserRepository>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IVoucherUsageRepository, VoucherUsageRepository>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            services.AddScoped<IFeedBackRepository, FeedBackRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Users
            services.AddScoped<IUserRepository, UserRepository>();
            //Authentication
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(databaseConnection);
            });

            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            return services;
        }
    }
}

using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Google.Cloud.Storage.V1;
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
            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IProductMaterialRepository, ProductMaterialRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Firebase
            services.AddSingleton(opt => StorageClient.Create());

            services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
            //Users
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //Authentication
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //Post
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

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

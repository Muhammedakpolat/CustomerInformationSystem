using CustomerInformationSystem.DataAccess.Contexts;
using CustomerInformationSystem.DataAccess.Repositories;
using CustomerInformationSystem.DataAccess.Repositories.CustomerAddresses;
using CustomerInformationSystem.DataAccess.Repositories.CustomerPhoneNumbers;
using CustomerInformationSystem.DataAccess.Repositories.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerInformationSystem.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.ConfigureDatabase(configuration);
            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultSQL"));
                });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerPhoneNumberRepository, CustomerPhoneNumberRepository>();
            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
            return services;
        }
    }
}

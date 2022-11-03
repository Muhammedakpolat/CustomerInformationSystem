using CustomerInformationSystem.Business.Services.CustomerAddresses;
using CustomerInformationSystem.Business.Services.CustomerPhoneNumbers;
using CustomerInformationSystem.Business.Services.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerInformationSystem.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.ConfigureServices();
            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerPhoneNumberService, CustomerPhoneNumberService>();
            services.AddTransient<ICustomerAddressService, CustomerAddressService>();
            return services;
        }
    }
}

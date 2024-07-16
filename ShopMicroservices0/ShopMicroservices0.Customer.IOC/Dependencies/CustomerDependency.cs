
using Microsoft.Extensions.DependencyInjection;
using ShopMicroservices0.Customers.Application.Contracts;
using ShopMicroservices0.Customers.Application.Services;
using ShopMicroservices0.Customers.Domain.Interfaces;
using ShopMicroservices0.Customers.Persistance.Repositories;


namespace ShopMicroservices0.Customers.IOC.Dependencies
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependency(this IServiceCollection service)
        {
            #region "Repositorio"
            service.AddScoped<ICustomersRepository, CustomerRepository>();
            #endregion

            service.AddTransient<ICustomerService, CustomerService>();
        }
    }
}

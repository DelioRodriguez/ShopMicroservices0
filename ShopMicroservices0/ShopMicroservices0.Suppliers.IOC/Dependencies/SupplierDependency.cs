
using Microsoft.Extensions.DependencyInjection;
using ShopMicroservices0.Suppliers.Application.Contracts;
using ShopMicroservices0.Suppliers.Application.Services;
using ShopMicroservices0.Suppliers.Domain.Interface;
using ShopMicroservices0.Suppliers.Persistance.Repositories;

namespace ShopMicroservices0.Suppliers.IOC.Dependencies
{
    public static class SupplierDependency
    {
        public static void AddSupplierDependency(this IServiceCollection service)
        {

            #region "Repositorios"

            service.AddScoped<ISupplierRepository, SupplierRepository>();
            #endregion

            #region "Servicios"
               service.AddScoped<ISupplierServices, SupplierServices>();
            #endregion
        }

    }
}

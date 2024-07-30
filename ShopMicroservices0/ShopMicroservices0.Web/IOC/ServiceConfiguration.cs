using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Services;

namespace ShopMicroservices0.Web.IOC;

public static class ServiceConfiguration
{
    public static void AddHttpClientServices(this IServiceCollection services)
    {
        services.AddHttpClient<ICategoriesServices, CategoriesServices>();
        services.AddHttpClient<ICustomerServices, CustomerServices>();
    }
}
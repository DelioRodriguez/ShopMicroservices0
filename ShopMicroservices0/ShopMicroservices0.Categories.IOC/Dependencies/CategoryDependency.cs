using Microsoft.Extensions.DependencyInjection;
using ShopMicroservices0.Categories.Application.Contracts;
using ShopMicroservices0.Categories.Application.Services;
using ShopMicroservices0.Categories.Domain.Entities;
using ShopMicroservices0.Categories.Domain.Interfaces;
using ShopMicroservices0.Categories.Persistance.Respositories;

namespace ShopMicroservices0.Categories.IOC.Dependencies
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection service)
        {
            #region "Repositorios"

            service.AddScoped<ICategoriesRepository, CategoryRepository>();

            #endregion

            #region Servicios

            service.AddTransient<ICategoryServices, CategoriesServices>();

            #endregion
        }


    }
}

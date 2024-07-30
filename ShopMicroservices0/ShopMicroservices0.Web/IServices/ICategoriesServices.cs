using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.IServices;

public interface ICategoriesServices
{
    Task<CategoriesGetListResult?> GetCategories();
    Task<CategoriesGetResult?> GetCategoriesById(int id);
    Task<BaseResult?> CreateCategories(CategoriesModel categories);
    Task<BaseResult?> UpdateCategories(int id, CategoriesModel categories);
    Task<BaseResult?> DeleteCategories(int id);
}
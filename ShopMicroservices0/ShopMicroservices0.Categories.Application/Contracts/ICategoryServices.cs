
using ShopMicroservices0.Categories.Application.DTO;
using ShopMicroservices0.Categories.Application.Base;

namespace ShopMicroservices0.Categories.Application.Contracts;

public interface ICategoryServices
{
    ServiceResult GetCategories();
    ServiceResult GetCategoriesById(int id);
    ServiceResult UpdateCategories(CategoriesDtoUpdate categoryDtoUpdate);
    ServiceResult RemoveCategories(CategoriesDtoRemove categoryDtoRemove);
    ServiceResult SaveCategories(CategoriesDtoSave dtoSave);
}
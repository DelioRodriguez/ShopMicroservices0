using Microsoft.Extensions.Logging;

using ShopMicroservices0.Categories.Application.Base;
using ShopMicroservices0.Categories.Application.Contracts;
using ShopMicroservices0.Categories.Application.DTO;
using ShopMicroservices0.Categories.Application.Extentions;
using ShopMicroservices0.Categories.Domain.Interfaces;

namespace ShopMicroservices0.Categories.Application.Services
{
    public class CategoriesServices : ICategoryServices
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly ILogger<CategoriesServices> logger;

        public CategoriesServices(ICategoriesRepository categoriesRepository, ILogger<CategoriesServices> logger)
        {
            this.categoriesRepository = categoriesRepository;
            this.logger = logger;
        }

        public ServiceResult GetCategories()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Result = (from category in categoriesRepository.GetAll()
                                 where category.deleted == false
                                 select new CategoriesGetAll()
                                 {
                                     CategoryId = category.Id,
                                     CategoryName = category.categoryName,
                                     CreaterUser = category.creation_user,
                                     Description = category.description,
                                     CreateDate = category.creation_date
                                 }).OrderByDescending(cd => cd.CreateDate).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorías.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult GetCategoriesById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var category = categoriesRepository.GetEntityByID(id);
                if (category != null && !category.deleted)
                {
                    result.Result = new CategoriesGetAll
                    {
                        CategoryId = category.Id,
                        CategoryName = category.categoryName,
                        CreaterUser = category.creation_user,
                        Description = category.description,
                        CreateDate = category.creation_date
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "Categoría no encontrada o eliminada";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la categoría por ID";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
        public ServiceResult UpdateCategories(CategoriesDtoUpdate categoryDtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = categoryDtoUpdate.IsValidCategory();

                if (!result.Success)
                    return result;

                Domain.Entities.Categories category = new Domain.Entities.Categories()
                {
                    Id = categoryDtoUpdate.CategoryId,
                    categoryName = categoryDtoUpdate.CategoryName,
                    description = categoryDtoUpdate.Description,
                    modify_user = categoryDtoUpdate.ChangeUser,
                    modify_date = categoryDtoUpdate.ChangeDate
                };

                categoriesRepository.Update(category);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult RemoveCategories(CategoriesDtoRemove categoryDtoRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (categoryDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(categoryDtoRemove)} es requerido.";
                    return result;
                }

                var category = new Domain.Entities.Categories()
                {
                    Id = categoryDtoRemove.Id,
                    deleted = categoryDtoRemove.Deleted,
                    delete_date = categoryDtoRemove.DeleteDate,
                    delete_user = categoryDtoRemove.UserDelete
                };

                categoriesRepository.Update(category);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }


        public ServiceResult SaveCategories(CategoriesDtoSave dtoSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = dtoSave.IsValidCategory();

                if (!result.Success)
                    return result;

                var category = new Domain.Entities.Categories()
                {
                    categoryName = dtoSave.CategoryName,
                    description = dtoSave.Description,
                    creation_user = dtoSave.ChangeUser,
                    creation_date = dtoSave.ChangeDate,
                    deleted = false
                };

                categoriesRepository.Save(category);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}

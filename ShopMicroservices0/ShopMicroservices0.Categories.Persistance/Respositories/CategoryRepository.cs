using System.Linq.Expressions;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using ShopMicroservices0.Categories.Domain.Interfaces;
using ShopMicroservices0.Categories.Persistance.Context;
using ShopMicroservices0.Categories.Persistance.Exceptions;

namespace ShopMicroservices0.Categories.Persistance.Respositories;

public class CategoryRepository : ICategoriesRepository
{
    private readonly ShopContext context;
    private readonly ILogger<CategoryRepository> Logger;

    public CategoryRepository(ShopContext context, ILogger<CategoryRepository> logger)
    {
        this.context = context;
        Logger = logger;
    }

    public List<Domain.Entities.Categories> GetAll()
    {
        return this.context.categories.ToList();
    }

    public Domain.Entities.Categories GetEntityByID(int id)
    {
        Domain.Entities.Categories? categories = null;
        try
        {
            categories = this.context.categories.Find(id);
            if (categories is null)
            {
                throw new CategoriesException("La categoria no se encuentra registrada");

            }

            return categories;
        }
        catch (Exception ex)
        {
            this.Logger.LogError("Error obteniendo la categoria", ex.ToString());
        }

        return categories;
    }

    public void Save(Domain.Entities.Categories entity)
    {
        try
        {
            if (entity is null)
            {
                throw new ArgumentNullException("La entidad de categoria no puede ser nulo");
            }
            if (Exists(co => co.categoryName.Equals(entity.categoryName)))
            {
                throw new CategoriesException("La categoria se encuentra registrada");
            }
            context.categories.Add(entity);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            this.Logger.LogError("Error agregando la categoria", e.ToString());
        }
    }

    public void Update(Domain.Entities.Categories entity)
    {
        try
        {
            if (entity is null)
            {
                throw new ArgumentException("La categoria no puede ser nula");
            }

            Domain.Entities.Categories? categoryToUpdate = this.context.categories.Find(entity.Id);
            if (categoryToUpdate is null)
            {
                throw new CategoriesException("La categoria ha actualizar no se encuentra registrada");
            }

            categoryToUpdate.categoryName = entity.categoryName;
            categoryToUpdate.description = entity.description;
            categoryToUpdate.modify_date = entity.modify_date;
            categoryToUpdate.modify_user = entity.modify_user;
            context.categories.Update(categoryToUpdate);
            context.SaveChanges();

        }
        catch (Exception e)
        {
            this.Logger.LogError("Error actualizando la categoria", e.ToString());
        }
    }

    public void Remove(Domain.Entities.Categories entity)
    {
        try
        {
            if (entity is null)
            {
                throw new ArgumentException("La categoria no puede ser nula");
            }

            Domain.Entities.Categories? categoryToRemove = this.context.categories.Find(entity.Id);
            if (categoryToRemove is null)
            {
                throw new CategoriesException("La categoria que desea eliminar no se encuentra registrada");
            }

            categoryToRemove.delete_user = entity.delete_user;
            categoryToRemove.deleted = entity.deleted;
            categoryToRemove.delete_date = entity.delete_date;
            context.categories.Update(categoryToRemove);
            this.context.SaveChanges();
        }
        catch (Exception e)
        {
            this.Logger.LogError("Error removiendo la categoria", e.ToString());
        }
    }

    public bool Exists(Expression<Func<Domain.Entities.Categories, bool>> filter)
    {
        return this.context.categories.Any(filter);
    }
}
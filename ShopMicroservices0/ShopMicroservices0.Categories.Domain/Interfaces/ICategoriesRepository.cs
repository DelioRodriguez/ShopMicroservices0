using ShopMicroservices0.Common.Data.Repository;

namespace ShopMicroservices0.Categories.Domain.Interfaces
{
    public interface ICategoriesRepository : IRepositoryBase<ShopMicroservices0.Categories.Domain.Entities.Categories, int>
    {

    }
}

using ShopMicroservices0.Common.Data.Repository;

namespace ShopMicroservices0.Suppliers.Domain.Interface
{
    public interface ISupplierRepository : IRepositoryBase<ShopMicroservices0.Suppliers.Domain.Entities.Suppliers,int>
    {
    }
}

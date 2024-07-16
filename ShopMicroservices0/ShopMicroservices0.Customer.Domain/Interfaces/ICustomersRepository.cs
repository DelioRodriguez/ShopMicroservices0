using ShopMicroservices0.Common.Data.Repository;


namespace ShopMicroservices0.Customers.Domain.Interfaces
{
    public interface ICustomersRepository : IRepositoryBase<ShopMicroservices0.Customers.Domain.Entities.Customers, int>
    {

    }

}


using ShopMicroservices0.Customers.Application.Base;
using ShopMicroservices0.Customers.Application.DTO;

namespace ShopMicroservices0.Customers.Application.Contracts
{
    public interface ICustomerService
    {
        ServiceResult GetCustomer();
        ServiceResult GetCustomerById(int id);
        ServiceResult UpdateCustomer(CustomerDtoUpdate customerDtoUpdate);
        ServiceResult RemoveCustomer(CustomerDtoRemove customerDtoRemove);
        ServiceResult SaveCustomer(CustomerDtoSave customerDtoSave);

    }
}

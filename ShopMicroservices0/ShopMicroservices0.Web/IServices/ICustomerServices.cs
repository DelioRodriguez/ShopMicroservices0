using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.IServices;

public interface ICustomerServices
{
    Task<CustomersGetListResult?> GetCustomer();
    Task<CustomersGetResult?> GetCustomerById(int id);
    Task<BaseResult?> CreateCustomer(CustomersModel  customers);
    Task<BaseResult?> UpdateCustomer(int id, CustomersModel customers);
    Task<BaseResult?> DeleteCustomer(int id);
}

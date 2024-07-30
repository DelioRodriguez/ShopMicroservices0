using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.IServices;

public interface ISupplierServices
{
    Task<SuppliersGetListResult?> GetSuppliers();
    Task<SuppliersGetResult?> GetSupplierById(int id);
    Task<BaseResult?> CreateSupplier(SuppliersModel  suppliers);
    Task<BaseResult?> UpdateSuppliers(int id, SuppliersModel suppliers);
    Task<BaseResult?> DeleteSuppliers(int id);
}
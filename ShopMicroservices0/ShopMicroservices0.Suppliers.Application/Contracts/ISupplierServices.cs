using ShopMicroservices0.Suppliers.Application.Base;
using ShopMicroservices0.Suppliers.Application.Dto;

namespace ShopMicroservices0.Suppliers.Application.Contracts;

public interface ISupplierServices
{
    ServicesResult GetSuppliers();
    ServicesResult GetSupplierById(int id);
    ServicesResult UpdateSupplier(SupplierDtoUpdate supplierDtoUpdate);
    ServicesResult RemoveSupplier(SupplierDtoRemove supplierDtoRemove);
    ServicesResult SaveSupplier(SupplierDtoSave supplierDtoSave);
}
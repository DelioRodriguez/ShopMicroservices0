

using Microsoft.Extensions.Logging;
using ShopMicroservices0.Suppliers.Application.Base;
using ShopMicroservices0.Suppliers.Application.Contracts;
using ShopMicroservices0.Suppliers.Application.Dto;
using ShopMicroservices0.Suppliers.Application.Extentions;
using ShopMicroservices0.Suppliers.Domain.Interface;

namespace ShopMicroservices0.Suppliers.Application.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly ILogger<SupplierServices> logger;

        public SupplierServices(ISupplierRepository supplierRepository,ILogger<SupplierServices> logger)
        {
            this.supplierRepository = supplierRepository;
            this.logger = logger;
        }

        public ServicesResult GetSupplierById(int id)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                var supplier = supplierRepository.GetEntityByID(id);
                if (supplier != null && !supplier.deleted)
                {
                    result.Result = new SupplierGetAll
                    {
                        SupplierID = supplier.Id,
                        ContactName = supplier.ContactName,
                        ContactTitle = supplier.ContactTitle,
                        CompanyName = supplier.CompanyName,
                        Address = supplier.Address,
                        City = supplier.City,
                        PostalCode = supplier.PostalCode,
                        Country = supplier.Country,
                        Phone = supplier.Phone,
                        Fax = supplier.Fax,
                        CreateDate = supplier.creation_date,
                        CreaterUser = supplier.creation_user
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "Suplidor no encontrado o se encuentra eliminado";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el suplidor";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult GetSuppliers()
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result.Result = (from supplier in supplierRepository.GetAll()
                                 select new SupplierGetAll()
                                 {
                                     SupplierID = supplier.Id,
                                     CompanyName = supplier.CompanyName,
                                     ContactName = supplier.ContactName,
                                     ContactTitle = supplier.ContactTitle,
                                     Address = supplier.Address,
                                     City = supplier.City,
                                     Region = supplier.Region,
                                     PostalCode = supplier.PostalCode,
                                     Country = supplier.Country,
                                     Phone = supplier.Phone,
                                     Fax = supplier.Fax,
                                     CreateDate = supplier.creation_date,
                                     CreaterUser = supplier.creation_user
                                 }).OrderByDescending(cd => cd.CreateDate).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult RemoveSupplier(SupplierDtoRemove supplierDtoRemove)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                if (supplierDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(supplierDtoRemove)} es requerido";
                    return result;
                }
                var supplier = new Domain.Entities.Suppliers()
                {
                    Id = supplierDtoRemove.Id,
                    deleted = supplierDtoRemove.Deleted,
                    delete_date = supplierDtoRemove.DeleteDate,
                    delete_user = supplierDtoRemove.UserDelete
                };
                supplierRepository.Update(supplier);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el suplidor";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult SaveSupplier(SupplierDtoSave dtoSave)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result = dtoSave.isValidSupplier();
                if (result.Success)
                {
                    return result;
                }
                var supplier = new Domain.Entities.Suppliers()
                {
                    CompanyName = dtoSave.CompanyName,
                    ContactName = dtoSave.ContactName,
                    ContactTitle = dtoSave.ContactTitle,
                    Address = dtoSave.Address,
                    Fax = dtoSave.Fax,
                    Phone = dtoSave.Phone,
                    City = dtoSave.City,
                    creation_date = dtoSave.ChangeDate,
                    creation_user = dtoSave.ChangeUser,
                    Country = dtoSave.Country,
                    PostalCode = dtoSave.PostalCode,
                    Region = dtoSave.Region,
                };
                supplierRepository.Save(supplier);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el suplidor";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServicesResult UpdateSupplier(SupplierDtoUpdate supplierDtoUpdate)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result = supplierDtoUpdate.isValidSupplier();
                if (!result.Success)
                {
                    return result;
                }
                Domain.Entities.Suppliers supplier = new Domain.Entities.Suppliers()
                {
                    Id = supplierDtoUpdate.SupplierID,
                    CompanyName = supplierDtoUpdate.CompanyName,
                    ContactName = supplierDtoUpdate.ContactName,
                    ContactTitle = supplierDtoUpdate.ContactTitle,
                    modify_date = supplierDtoUpdate.ChangeDate,
                    modify_user = supplierDtoUpdate.ChangeUser,
                    Country = supplierDtoUpdate.Country,
                    Phone = supplierDtoUpdate.Phone,
                    Fax = supplierDtoUpdate.Fax,
                    City = supplierDtoUpdate.City,
                    Region = supplierDtoUpdate.Region,
                    Address = supplierDtoUpdate.Address,
                    PostalCode = supplierDtoUpdate.PostalCode,

                };
                supplierRepository.Update(supplier);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el suplidor";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }
    }
}

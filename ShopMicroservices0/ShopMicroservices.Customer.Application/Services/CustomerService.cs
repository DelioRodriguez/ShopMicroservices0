using Microsoft.Extensions.Logging;
using ShopMicroservices0.Customers.Application.Base;
using ShopMicroservices0.Customers.Application.Contracts;
using ShopMicroservices0.Customers.Application.DTO;
using ShopMicroservices0.Customers.Domain.Interfaces;
using ShopMicroservices0.Customers.Persistance.Repositories;
using ShopMicroServices0.Customers.Application.Extentions;


namespace ShopMicroservices0.Customers.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ICustomersRepository customersRepository, ILogger<CustomerService> logger)
        {
            this.customersRepository = customersRepository;
            this.logger = logger;
        }

        public ServiceResult GetCustomer()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Result = (from customer in customersRepository.GetAll()
                                 select new CustomerGetAll()
                                 {
                                     custiId = customer.Id,
                                     companyName = customer.companyName,
                                     contactName = customer.contactName,
                                     contactTitle = customer.contactTitle,
                                     postalCode = customer.postalCode,
                                     Phone = customer.phone,
                                     country = customer.country,
                                     City = customer.city,
                                     Address = customer.Address,
                                     email = customer.Email,
                                     fax = customer.fax,
                                     region = customer.region,
                                 }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los customers.";
                this.logger.LogError(result.Message, ex);
            }
            return result;


        }

        public ServiceResult GetCustomerById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var customer = customersRepository.GetEntityByID(id);
                if (customer != null)
                {
                    result.Result = new CustomerGetAll
                    {
                        custiId = customer.Id,
                        companyName = customer.companyName,
                        contactName = customer.contactName,
                        contactTitle = customer.contactTitle,
                        postalCode = customer.postalCode,
                        Phone = customer.phone,
                        country = customer.country,
                        City = customer.city,
                        Address = customer.Address,
                        email = customer.Email,
                        fax = customer.fax,
                        region = customer.region,
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "Customer no encontrada ";
                }
            }
            catch (Exception e)

            {
                result.Success = false;
                result.Message = "Error obteniendo el customer";
                this.logger.LogError(result.Message, e);
            }
            return result;


        }

        public ServiceResult RemoveCustomer(CustomerDtoRemove customerDtoRemove)
        {
            var result = new ServiceResult();
            try
            {
                var customer = customersRepository.GetEntityByID(customerDtoRemove.custiId);

                customersRepository.Remove(customer);
                result.Message = "Customer eliminado correctamente";

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error eliminando customer");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult SaveCustomer(CustomerDtoSave customerDtoSave)
        {
            var result = new ServiceResult();
            try
            {
                result = customerDtoSave.IsValidCustomer();
                if (!result.Success)
                    return result;

                var customer = new Domain.Entities.Customers
                {
                    Id = customerDtoSave.custiId,
                    companyName = customerDtoSave.companyName,
                    contactName = customerDtoSave.contactName,
                    contactTitle = customerDtoSave.contactTitle,
                    Address = customerDtoSave.Address,
                    Email = customerDtoSave.email,
                    city = customerDtoSave.City,
                    region = customerDtoSave.region,
                    postalCode = customerDtoSave.postalCode,
                    country = customerDtoSave.country,
                    phone = customerDtoSave.Phone,
                    fax = customerDtoSave.fax
                };

                customersRepository.Save(customer);
                result.Result = customer;
                result.Message = "Customer guardado con exito";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error guardando customer");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ServiceResult UpdateCustomer(CustomerDtoUpdate customerDtoUpdate)
        {
            var result = new ServiceResult();
            try
            {
                result = customerDtoUpdate.IsValidCustomer();
                if (!result.Success)
                    return result;

                var customer = customersRepository.GetEntityByID(customerDtoUpdate.custiId);

                customer.companyName = customerDtoUpdate.companyName;
                customer.contactName = customerDtoUpdate.contactName;
                customer.contactTitle = customerDtoUpdate.contactTitle;
                customer.Address = customerDtoUpdate.Address;
                customer.Email = customerDtoUpdate.email;
                customer.city = customerDtoUpdate.City;
                customer.region = customerDtoUpdate.region;
                customer.postalCode = customerDtoUpdate.postalCode;
                customer.country = customerDtoUpdate.country;
                customer.phone = customerDtoUpdate.Phone;
                customer.fax = customerDtoUpdate.fax;

                customersRepository.Update(customer);
                result.Result = customer;
                result.Message = "Customer actualizado con exito";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error actualizando Customer.");
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}

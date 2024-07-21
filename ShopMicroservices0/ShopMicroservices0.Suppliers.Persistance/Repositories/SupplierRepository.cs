

using Microsoft.Extensions.Logging;
using ShopMicroservices0.Suppliers.Domain.Interface;
using ShopMicroservices0.Suppliers.Persistance.Context;
using ShopMicroservices0.Suppliers.Persistance.Exceptions;
using System.Linq.Expressions;

namespace ShopMicroservices0.Suppliers.Persistance.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopContext context;
        private readonly ILogger<SupplierRepository> logger;

        public SupplierRepository(ShopContext context, ILogger<SupplierRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }



        public List<Domain.Entities.Suppliers> GetAll()
        {
            return this.context.Suppliers.ToList();
        }

        public Domain.Entities.Suppliers GetEntityByID(int id)
        {
            Domain.Entities.Suppliers? Suppliers = null;
            try
            {
                Suppliers = this.context.Suppliers.Find(id);
                if (Suppliers == null)
                {
                    throw new SupplierException("El suplidor no se encuentra registrado");

                }
                return Suppliers;
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo el suplidor", ex.ToString());
            }
            return Suppliers;
        }

        public void Remove(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("El suplidor no puede ser nulo");
                }
                Domain.Entities.Suppliers? supplierToRemove = this.context.Suppliers.Find(entity.Id);
                if (supplierToRemove == null)
                {
                    throw new SupplierException("El suplidor que desea eliminar no se encuentra registrado");
                }
                supplierToRemove.deleted = entity.deleted;
                supplierToRemove.delete_user = entity.delete_user;
                supplierToRemove.delete_date = entity.delete_date;
                context.Suppliers.Update(supplierToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el suplidor", ex.ToString(), ex);
            }

        }

        public void Save(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("La entidad de suplidor no puede ser nula");
                }
                if (Exists(co => co.CompanyName.Equals(entity.CompanyName)))
                {
                    throw new SupplierException("El contacto del supplidor ya se encuentra registrado");
                }
                context.Suppliers.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error agregando el suplidor ", ex.ToString());
            }
        }

        public void Update(Domain.Entities.Suppliers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("El suplidor no puede ser nulo");
                }
                Domain.Entities.Suppliers? supplierToUpdate = this.context.Suppliers.Find(entity.Id);
                if (supplierToUpdate is null)
                {
                    throw new SupplierException("El suplidor ha actualizxar no se encuentra registrado");
                }
                supplierToUpdate.CompanyName = entity.CompanyName;
                supplierToUpdate.ContactName = entity.ContactName;
                supplierToUpdate.ContactTitle = entity.ContactTitle;
                supplierToUpdate.Address = entity.Address;
                supplierToUpdate.City = entity.City;
                supplierToUpdate.Region = entity.Region;
                supplierToUpdate.PostalCode = entity.PostalCode;
                supplierToUpdate.Country = entity.Country;
                supplierToUpdate.Phone = entity.Phone;
                supplierToUpdate.Fax = entity.Fax;
                supplierToUpdate.modify_date = entity.modify_date;
                supplierToUpdate.modify_user = entity.modify_user;

                context.Suppliers.Update(supplierToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando suplidor", ex.ToString());
            }

        }
        public bool Exists(Expression<Func<Domain.Entities.Suppliers, bool>> filter)
        {
           return this.context.Suppliers.Any(filter);
        }
    }
}

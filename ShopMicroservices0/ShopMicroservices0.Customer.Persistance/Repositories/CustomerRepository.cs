using Microsoft.Extensions.Logging;
using ShopMicroservices0.Customers.Domain.Interfaces;
using ShopMicroservices0.Customers.Persistance.Context;
using System.Linq.Expressions;


namespace ShopMicroservices0.Customers.Persistance.Repositories
{
    public class CustomerRepository : ICustomersRepository
    {

        private readonly ShopContext context;
        private readonly ILogger<CustomerRepository> logger;

        public CustomerRepository(ShopContext context, ILogger<CustomerRepository> logger)
        {
            this.logger = logger;
            this.context = context;
        }
        public bool Exists(Expression<Func<Domain.Entities.Customers, bool>> filter)
        {
            return this.context.Customers.Any(filter);
        }

        public List<Domain.Entities.Customers> GetAll()
        {
            return this.context.Customers.ToList();
        }

        public Domain.Entities.Customers GetEntityByID(int id)
        {
            Domain.Entities.Customers? customers = null;
            try
            {
                customers = this.context.Customers.Find(id);

                if (customers is null)
                {
                    throw new ShopMicroservices0.Customers.Persistance.Exceptions.CustomerExceptions("El customer no se encvuentra registrado");
                }
                return customers;
            }
            catch (Exception e)
            {
                this.logger.LogError("Error agregando la categoria", e.ToString());
            }
            return customers;

        }

        public void Remove(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentException(" EL customer debe existir");

                }
                Domain.Entities.Customers? CustomerToRemove = this.context.Customers.Find(entity.Id);

                if (CustomerToRemove is null)
                    throw new Persistance.Exceptions.CustomerExceptions("El customer que desea eliminar no se encuentra registrado");
                context.Customers.Remove(CustomerToRemove);
                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                this.logger.LogError("Error removiendo el customer", e.ToString());
            }
        }

        public void Save(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentException("La entidad de customer no puede ser nulo");
                }
                if (Exists(co => co.companyName == entity.companyName))
                {
                    throw new Persistance.Exceptions.CustomerExceptions("La company ya fue agg");
                }
                context.Customers.Add(entity);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                this.logger.LogError("Error agregando el customer", e.ToString());
            }
        }

        public void Update(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentException("El customer no puede ser nulo");
                }
                Domain.Entities.Customers? customerToUpdate = this.context.Customers.Find(entity.Id);
                if (customerToUpdate is null)
                {
                    throw new Persistance.Exceptions.CustomerExceptions("El customer ha actualizar no se encuentra registrada");

                }
                customerToUpdate.companyName = entity.companyName;
                customerToUpdate.contactName = entity.contactName;
                customerToUpdate.Address = entity.Address;
                customerToUpdate.fax = entity.fax;
                customerToUpdate.phone = entity.phone;
                customerToUpdate.country = entity.country;
                customerToUpdate.city = entity.city;
                customerToUpdate.contactTitle = entity.contactTitle;
                customerToUpdate.postalCode = entity.postalCode;
                customerToUpdate.region = entity.region;
                customerToUpdate.Email = entity.Email;

                context.Customers.Update(customerToUpdate);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                this.logger.LogError("Error actualizando la categoria", e.ToString());
            }
        }
    }
}

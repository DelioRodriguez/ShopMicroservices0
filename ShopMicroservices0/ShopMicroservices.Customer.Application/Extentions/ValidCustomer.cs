using ShopMicroservices0.Customers.Application.Base;
using ShopMicroservices0.Customers.Application.DTO;


namespace ShopMicroServices0.Customers.Application.Extentions
{
    public static class ValidCustomers
    {
        public static ServiceResult IsValidCustomer(this DtoBaseCustomer baseCustomer)
        {
            ServiceResult results = new ServiceResult();

            if (baseCustomer is null)
            {
                results.Success = false;
                results.Message = $"El objeto {nameof(baseCustomer)} es requerido.";
                return results;
            }



            if (string.IsNullOrEmpty(baseCustomer.companyName))
            {
                results.Success = false;
                results.Message = "El nombre de la compañia es requerido.";
                return results;
            }
            if (baseCustomer.companyName.Length > 40)
            {
                results.Success = false;
                results.Message = "El nombre de la compañia no puede ser mayor a 40 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.contactName))
            {
                results.Success = false;
                results.Message = "El nombre de contacto es invalido.";
                return results;
            }
            if (baseCustomer.contactName.Length > 30)
            {
                results.Success = false;
                results.Message = "El nombre de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.contactTitle))
            {
                results.Success = false;
                results.Message = "El titulo de contacto es invalido.";
                return results;
            }
            else if (baseCustomer.contactTitle.Length > 30)
            {
                results.Success = false;
                results.Message = "El titulo de contacto no puede ser mayor a 30 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Address))
            {
                results.Success = false;
                results.Message = "La direccion es invalida.";
                return results;
            }
            else if (baseCustomer.Address.Length > 60)
            {
                results.Success = false;
                results.Message = "La direccion no puede ser mayor a 60 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.email))
            {
                results.Success = false;
                results.Message = "El email es invalido.";
                return results;
            }
            else if (baseCustomer.email.Length > 50)
            {
                results.Success = false;
                results.Message = "El email no puede ser mayor a 50 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.City))
            {
                results.Success = false;
                results.Message = "La ciudad es invalida.";
                return results;
            }
            else if (baseCustomer.City.Length > 15)
            {
                results.Success = false;
                results.Message = "La ciudad no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (baseCustomer.region.Length > 15)
            {
                results.Success = false;
                results.Message = "La region no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (baseCustomer.postalCode.Length > 10)
            {
                results.Success = false;
                results.Message = "El codigo postal no puede ser mayor a 10 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.country))
            {
                results.Success = false;
                results.Message = "El pais es invalido.";
                return results;
            }
            else if (baseCustomer.country.Length > 15)
            {
                results.Success = false;
                results.Message = "El pais no puede ser mayor a 15 caracteres.";
                return results;
            }

            if (string.IsNullOrEmpty(baseCustomer.Phone))
            {
                results.Success = false;
                results.Message = "El telefono es invalido.";
                return results;
            }
            else if (baseCustomer.Phone.Length > 24)
            {
                results.Success = false;
                results.Message = "El telefono no puede ser mayor a 24 caracteres.";
                return results;
            }

            if (baseCustomer.fax.Length > 24)
            {
                results.Success = false;
                results.Message = "El fax no puede ser mayor a 24 caracteres.";
                return results;
            }

            results.Success = true;
            results.Message = "Validacion exitosa.";
            return results;
        }
    }
}
using ShopMicroservices0.Suppliers.Application.Base;
using ShopMicroservices0.Suppliers.Application.Dto;

namespace ShopMicroservices0.Suppliers.Application.Extentions;

public static class ValidCSupplier
{
    public static ServicesResult isValidSupplier(this DtoBaseSupplier baseSupplier)
    {
        ServicesResult Result = new ServicesResult();
        if (baseSupplier is null)
        {
            Result.Success = false;
            Result.Message = $"El objeto {nameof(baseSupplier)} no puede ser null";
            return Result;
        }

        if (baseSupplier.CompanyName is null)
        {
            Result.Success = false;
            Result.Message = "El nombre de compaany no puede ser nulo";
            return Result;
        }

        if (baseSupplier.CompanyName.Length > 40)
        {
            Result.Success = false;
            Result.Message = "El nombre de la company no puede ser mayor a 40";
            return Result;
        }

        if (baseSupplier.ContactName is null)
        {
            Result.Success = false;
            Result.Message = "El nombre de contacto es requerido";
            return Result;
        }

        if (baseSupplier.ContactName.Length > 30)
        {
            Result.Success = false;
            Result.Message = "El nombre de contacto no puede tener mas de 30 caracteres";
            return Result;
        }

        if (baseSupplier.ContactTitle is null)
        {
            Result.Success = false;
            Result.Message = "El titulo de contacto es requerido";
            return Result;
        }

        if (baseSupplier.ContactTitle.Length > 30)
        {
            Result.Success = false;
            Result.Message = "El titulo no puede tener mas de 30 caracteres";
            return Result;
        }

        if (baseSupplier.Address is null)
        {
            Result.Success = false;
            Result.Message = "El address es requerido";
            return Result;
        }

        if (baseSupplier.Address.Length > 60)
        {
            Result.Success = false;
            Result.Message = "El address no puede contener mas de 60 caracteres";
            return Result;
        }

        if (baseSupplier.City is null)
        {
            Result.Success = false;
            Result.Message = "La ciudad es requerida";
            return Result;
        }

        if (baseSupplier.City.Length > 15)
        {
            Result.Success = false;
            Result.Message = "La ciudad no puede contener mas de 15 caracteres";

        }

        if (baseSupplier.Region.Length > 15)
        {
            Result.Success = false;
            Result.Message = "La region no puede tener mas de 15 caracteres";
            return Result;
        }

        if (baseSupplier.PostalCode.Length > 10)
        {
            Result.Success = false;
            Result.Message = "El codigo postal no puede tener mas de 10 caracteres";
            return Result;
        }

        if (baseSupplier.Country is null)
        {
            Result.Success = false;
            Result.Message = "El country es requerido";
            return Result;
        }

        if (baseSupplier.Country.Length > 15)
        {
            Result.Success = false;
            Result.Message = " COuntry no puede tener mas de 15 caracteres";
            return Result;
        }

        if (baseSupplier.Phone is null)
        {
            Result.Success = false;
            Result.Message = "El numero de telefono es requerido";
            return Result;
        }

        if (baseSupplier.Phone.Length > 24)
        {
            Result.Success = false;
            Result.Message = "El numero de telefono no puede ncontener mas de 24 caracteres";
            return Result;
        }

        if (baseSupplier.Fax.Length > 24)
        {
            Result.Success = false;
            Result.Message = "EL numero de fax no puede contener mas de 24 caracteres.";
            return Result;
        }




        return Result;
    }
}
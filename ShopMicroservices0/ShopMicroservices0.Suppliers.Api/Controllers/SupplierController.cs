using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Suppliers.Application.Contracts;
using ShopMicroservices0.Suppliers.Application.Dto;

namespace ShopMicroservices0.Suppliers.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierServices supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }

        [HttpGet("GetSuppliers")]
        public IActionResult Get()
        {
            var result = this.supplierServices.GetSuppliers();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetSupplierByID")]
        public IActionResult Get(int id)
        {
            var result = this.supplierServices.GetSupplierById(id);
            if (!result.Success)
            {

                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveSuppliers")]
        public IActionResult Post([FromBody] SupplierDtoSave dtoSave)
        {
            var result = this.supplierServices.SaveSupplier(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateSupplier")]
        public IActionResult Post(SupplierDtoUpdate dtoUpdate)
        {
            var result = this.supplierServices.UpdateSupplier(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("DeleteSupplier")]
        public IActionResult Post(SupplierDtoRemove dtoRemove)
        {
            var result = this.supplierServices.RemoveSupplier(dtoRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

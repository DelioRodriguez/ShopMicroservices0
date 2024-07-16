using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Customers.Application.Contracts;
using ShopMicroservices0.Customers.Application.DTO;

namespace ShopMicroservices0.CustomersAdm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public IActionResult Get()
        {
            var result = this.customerService.GetCustomer();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerByID")]
        public IActionResult Get(int id)
        {
            var result = this.customerService.GetCustomerById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("SaveCustomers")]
        public IActionResult Post([FromBody] CustomerDtoSave dtoSave)
        {
            var result = this.customerService.SaveCustomer(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("UpdateCustomers")]
        public IActionResult Post(CustomerDtoUpdate dtoUpdate)
        {
            var result = this.customerService.UpdateCustomer(dtoUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("DeleteCustomers")]
        public IActionResult Post(CustomerDtoRemove dtoRemove)
        {
            var result = this.customerService.RemoveCustomer(dtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}

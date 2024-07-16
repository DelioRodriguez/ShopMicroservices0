using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Categories.Application.Contracts;
using ShopMicroservices0.Categories.Application.DTO;

namespace ShopMicroservices0.Categories.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryServices CategoryServices;

    public CategoryController(ICategoryServices categoryServices)
    {
        this.CategoryServices = categoryServices;
    }

    [HttpGet("GetCategories")]
    public IActionResult Get()
    {
        var result = this.CategoryServices.GetCategories();
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("GetCategoriesByID")]
    public IActionResult Get(int id)
    {
        var result = this.CategoryServices.GetCategoriesById(id);

        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPost("SaveCategories")]
    public IActionResult Post([FromBody] CategoriesDtoSave dtoSave)
    {
        var result = this.CategoryServices.SaveCategories(dtoSave);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("UpdateCategories")]
    public IActionResult Post(CategoriesDtoUpdate dtoUpdate)
    {
        var result = this.CategoryServices.UpdateCategories(dtoUpdate);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("DeleteCategories")]
    public IActionResult Post(CategoriesDtoRemove dtoRemove)
    {
        var result = this.CategoryServices.RemoveCategories(dtoRemove);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
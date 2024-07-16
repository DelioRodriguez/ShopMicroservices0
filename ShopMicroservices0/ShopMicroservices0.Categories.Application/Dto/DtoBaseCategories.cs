using ShopMicroservices0.Categories.Application.DTO;

namespace ShopMicroservices0.Categories.Application.DTO;

public abstract class DtoBaseCategories : DtoBase
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }


}
namespace ShopMicroservices0.Categories.Application.DTO;

public class CategoriesGetAll
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public int CreaterUser { get; set; }
    public DateTime CreateDate { get; set; }
}
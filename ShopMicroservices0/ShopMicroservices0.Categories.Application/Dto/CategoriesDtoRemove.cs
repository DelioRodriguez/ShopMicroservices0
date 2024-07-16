namespace ShopMicroservices0.Categories.Application.DTO;

public class CategoriesDtoRemove
{
    public int Id { get; set; }
    public int UserDelete { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool Deleted { get; set; }
}
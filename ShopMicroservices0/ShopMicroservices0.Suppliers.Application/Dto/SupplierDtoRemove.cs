namespace ShopMicroservices0.Suppliers.Application.Dto;

public class SupplierDtoRemove 
{
    public int Id { get; set; }
    public int UserDelete { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool Deleted { get; set; }
}
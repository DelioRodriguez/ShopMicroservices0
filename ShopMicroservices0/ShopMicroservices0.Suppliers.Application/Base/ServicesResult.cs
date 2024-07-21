namespace ShopMicroservices0.Suppliers.Application.Base;

public class ServicesResult
{
    public ServicesResult() => this.Success = true;

    public string? Message { set; get; }
    public bool Success { get; set; }
    
    public dynamic Result { get; set; }
    
}
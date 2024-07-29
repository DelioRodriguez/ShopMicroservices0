using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class CustomersGetResult : BaseResult
{
    public CustomersModel result { get; set; }
}
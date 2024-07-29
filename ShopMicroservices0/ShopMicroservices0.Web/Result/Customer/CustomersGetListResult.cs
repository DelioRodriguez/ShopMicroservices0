using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class CustomersGetListResult : BaseResult
{
 
    public List<CustomersModel> result { get; set; }
}
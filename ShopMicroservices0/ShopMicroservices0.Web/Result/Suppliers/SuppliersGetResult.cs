using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class SuppliersGetResult : BaseResult
{
    public SuppliersModel result { get; set; }
}
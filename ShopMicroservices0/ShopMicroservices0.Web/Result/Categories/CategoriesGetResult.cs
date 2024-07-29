using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class CategoriesGetResult : BaseResult
{
    public CategoriesModel result { get; set; }
    
}
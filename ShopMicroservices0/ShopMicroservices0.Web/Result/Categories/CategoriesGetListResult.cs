using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class CategoriesGetListResult : BaseResult
{
   
    public List<CategoriesModel> result { get; set; }

    
}
using ShopMicroservices0.Web.Models;

namespace ShopMicroservices0.Web.Result;

public class SuppliersGetListResult : BaseResult
{
   
    public List<SuppliersModel> result { get; set; }
}
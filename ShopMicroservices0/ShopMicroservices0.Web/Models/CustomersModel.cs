namespace ShopMicroservices0.Web.Models;

public class CustomersModel
{
    public int custId { get; set; }
    public string companyName { get; set; }
    public string contactTitle { get; set; }
    public string contactName { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string email { get; set; }
    public string? region { get; set; }
    public string? postalCode { get; set; }
    public string country { get; set; }
    public string phone { get; set; }
    public string? fax { get; set; }
}
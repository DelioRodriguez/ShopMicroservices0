using Newtonsoft.Json;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Services;

public class CustomerServices : ICustomerServices
{
    private readonly HttpClient _httpClient;


    public CustomerServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CustomersGetListResult?> GetCustomer()
    {
        var response = await _httpClient.GetAsync($"http://localhost:5005/api/Customer/GetCustomers");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<CustomersGetListResult>(apiResponse);
    }

    public async Task<CustomersGetResult?> GetCustomerById(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5005/api/Customer/GetCustomerByID?id=0");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);
    }

    public async Task<BaseResult?> CreateCustomer(CustomersModel customers)
    {
        var jsonContent = JsonConvert.SerializeObject(customers);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"http://localhost:5005/api/Customer/SaveCustomers", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> UpdateCustomer(int id, CustomersModel customers)
    {
        var jsonContent = JsonConvert.SerializeObject(customers);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"http://localhost:5005/api/Customer/UpdateCustomers?id={id}",
            contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> DeleteCustomer(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5005/api/Customer/DeleteCustomers?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
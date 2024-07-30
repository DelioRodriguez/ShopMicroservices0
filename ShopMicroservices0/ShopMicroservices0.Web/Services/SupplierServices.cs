using Newtonsoft.Json;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Services;

public class SupplierServices : ISupplierServices

{
    private readonly HttpClient _httpClient;

    public SupplierServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<SuppliersGetListResult?> GetSuppliers()
    {
        var response = await _httpClient.GetAsync($"http://localhost:5041/api/Supplier/GetSuppliers");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);
    }

    public async Task<SuppliersGetResult?> GetSupplierById(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5041/api/Supplier/GetSupplierByID?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);
    }

    public async Task<BaseResult?> CreateSupplier(SuppliersModel suppliers)
    {
        var jsonContent = JsonConvert.SerializeObject(suppliers);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"http://localhost:5041/api/Supplier/SaveSuppliers", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> UpdateSuppliers(int id, SuppliersModel suppliers)
    {
        var jsonContent = JsonConvert.SerializeObject(suppliers);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response =
            await _httpClient.PutAsync($"http://localhost:5041/api/Supplier/UpdateSupplier?id={id}", contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> DeleteSuppliers(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5041/api/Supplier/DeleteSupplier?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
using Newtonsoft.Json;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Services;

public class CategoriesServices : ICategoriesServices
{
    private readonly HttpClient _httpClient;

    public CategoriesServices(HttpClient httpClient)
    {
        this._httpClient = httpClient;

    }
    
    
    public async Task<CategoriesGetListResult?> GetCategories()
    {
        var response = await _httpClient.GetAsync($"http://localhost:5228/api/Category/GetCategories\n");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<CategoriesGetListResult>(apiResponse);
    }

    public async Task<CategoriesGetResult?> GetCategoriesById(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5228/api/Category/GetCategoriesByID?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
    }

    public async Task<BaseResult?> CreateCategories(CategoriesModel categories)
    {
        var jsonContent = JsonConvert.SerializeObject(categories);
        var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5228/api/Category/SaveCategories",contentString);
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> UpdateCategories(int id, CategoriesModel categories)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5228/api/Category/UpdateCategories?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }

    public async Task<BaseResult?> DeleteCategories(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5228/api/Category/DeleteCategories?id={id}");
        response.EnsureSuccessStatusCode();
        var apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BaseResult>(apiResponse);
    }
}
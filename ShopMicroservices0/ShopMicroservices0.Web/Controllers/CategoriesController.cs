using System.Net.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Controllers;

public class CategoriesController : Controller
{
    private HttpClientHandler HttpClientHandler = new HttpClientHandler();

    public CategoriesController()
    {
        this.HttpClientHandler = new HttpClientHandler();
        this.HttpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };
    }
    // GET: CategoryController
    public async Task<ActionResult> Index()
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetAsync("http://localhost:5228/api/Category/GetCategories");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetListResult>(apiResponse);

                // Verifica que el resultado y su lista no sean nulos
                if (categoriesGetResult != null && categoriesGetResult.success && categoriesGetResult.result != null)
                {
                    return View(categoriesGetResult.result);
                }

                ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
                return View(new List<CategoriesModel>());
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(new List<CategoriesModel>());
            }
        }
    }
    
    //GET: CategoriesController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var response =
                    await httpClient.GetAsync($"http://localhost:5228/api/Category/GetCategoriesByID?id={id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);

                if (categoriesGetResult != null && categoriesGetResult.success)
                {
                    return View(categoriesGetResult.result);
                }
                else
                {
                    ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
                    return View();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View();
            }
        }
    }
    //GET : CategoriesController/Create
    public ActionResult Create()
    {
        return View();
    }
    
    //POST: CategoriesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CategoriesModel categories)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(categories);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5228/api/Category/SaveCategories",contentString);
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);
                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result?.message ?? "Error desconocido";
                    return View(categories);
                }
            }
            catch (HttpRequestException e)
            {
                ViewBag.Message = $"Error en la solicitud HTPP: {e.Message}";
                return View(categories);
            }
        }
    }
    //GET:CategoriesController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try{
            var response = await httpClient.GetAsync($"http://localhost:5228/api/Category/GetCategoriesByID?id{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);
            
            if (categoriesGetResult != null && categoriesGetResult.success)
            {
                return View(categoriesGetResult.result);
            }
            else
            {
                ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
                return View();
            }
        }
        catch (HttpRequestException ex)
        {
            ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
            return View();
        }
            
            
    }
}
 

    // POST: CategoriesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CategoriesModel categories)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(categories);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response =
                    await httpClient.PutAsync($"http://localhost:4970/api/Customer/UpdateCustomer?id={id}",
                        contentString);
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result?.message ?? "Error desconocido";
                    return View(categories);
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(categories);
            }
        }
    }

    // GET: CustomersController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var response = await httpClient.GetAsync($"http://localhost:5228/api/Category/GetCategoriesByID?id{id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var categoriesGetResult = JsonConvert.DeserializeObject<CategoriesGetResult>(apiResponse);

                if (categoriesGetResult != null && categoriesGetResult.success)
                {
                    return View(categoriesGetResult.result);
                }
                else
                {
                    ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
                    return View();
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View();
            }
        }
    }
    
    // POST: CustomersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler ))
        {
            try
            {
                var response = await httpClient.DeleteAsync($"http://localhost:5228/api/Category/DeleteCategories?id={id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BaseResult>(apiResponse);

                if (result != null && result.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result?.message ?? "Error desconocido";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }

}


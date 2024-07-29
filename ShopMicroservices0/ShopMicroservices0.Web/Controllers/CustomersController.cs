using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Controllers;

public class CustomersController : Controller
{
     private HttpClientHandler HttpClientHandler = new HttpClientHandler();

    public CustomersController()
    {
        this.HttpClientHandler = new HttpClientHandler();
        this.HttpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };
    }
    // GET: CustomersController
    public async Task<ActionResult> Index()
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetAsync("http://localhost:5005/api/Customer/GetCustomers");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var customerGetResult = JsonConvert.DeserializeObject<CustomersGetListResult>(apiResponse);

                // Verifica que el resultado y su lista no sean nulos
                if (customerGetResult != null && customerGetResult.success && customerGetResult.result != null)
                {
                    return View(customerGetResult.result);
                }

                ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
                return View(new List<CustomersModel>());
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(new List<CustomersModel>());
            }
        }
    }
    
    // GET: CustomersController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var response =
                    await httpClient.GetAsync($"http://localhost:4970/api/Customer/GetCustomerById?id={id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var customerGetResult = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);

                if (customerGetResult != null && customerGetResult.success)
                {
                    return View(customerGetResult.result);
                }
                else
                {
                    ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
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

    //GET : CustomersController/Create
    public ActionResult Create()
    {
        return View();
    }
    
    //POST: CustomersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CustomersModel customers)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(customers);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5005/api/Customer/SaveCustomers",contentString);
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
                    return View(customers);
                }
            }
            catch (HttpRequestException e)
            {
                ViewBag.Message = $"Error en la solicitud HTPP: {e.Message}";
                return View(customers);
            }
        }
    }
    //GET:CustomersController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try{
            var response = await httpClient.GetAsync($"http://localhost:5005/api/Customer/GetCustomerByID?id{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var customersGetResult = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);
            
            if (customersGetResult != null && customersGetResult.success)
            {
                return View(customersGetResult.result);
            }
            else
            {
                ViewBag.Message = customersGetResult.message ?? "Error desconocido";
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
 

    // POST: CustomersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CustomersModel customers)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(customers);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response =
                    await httpClient.PutAsync($"http://localhost:5005/api/Customer/UpdateCustomers?id={id}",
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
                    return View(customers);
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(customers);
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
                var response = await httpClient.GetAsync($"http://localhost:5005/api/Customer/GetCustomerByID?id{id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var customersGetResult = JsonConvert.DeserializeObject<CustomersGetResult>(apiResponse);

                if (customersGetResult != null && customersGetResult.success)
                {
                    return View(customersGetResult.result);
                }
                else
                {
                    ViewBag.Message = customersGetResult?.message ?? "Error desconocido";
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
                var response = await httpClient.DeleteAsync($"http://localhost:5005/api/Customer/DeleteCustomers?id={id}");
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
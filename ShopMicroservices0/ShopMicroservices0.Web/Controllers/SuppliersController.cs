using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopMicroservices0.Web.Models;
using ShopMicroservices0.Web.Result;

namespace ShopMicroservices0.Web.Controllers;

public class SuppliersController : Controller
{
    private HttpClientHandler HttpClientHandler = new HttpClientHandler();

    public SuppliersController()
    {
        this.HttpClientHandler = new HttpClientHandler();
        this.HttpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };
    }
    // GET: SuppliersController
    public async Task<ActionResult> Index()
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.GetAsync("http://localhost:5041/api/Supplier/GetSuppliers");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetListResult>(apiResponse);

                // Verifica que el resultado y su lista no sean nulos
                if (suppliersGetResult != null && suppliersGetResult.success && suppliersGetResult.result != null)
                {
                    return View(suppliersGetResult.result);
                }

                ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
                return View(new List<SuppliersModel>());
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(new List<SuppliersModel>());
            }
        }
    }
    
    //GET: SuppliersController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var response =
                    await httpClient.GetAsync($"http://localhost:5041/api/Supplier/GetSupplierByID?id={id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var supplierGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);

                if (supplierGetResult != null && supplierGetResult.success)
                {
                    return View(supplierGetResult.result);
                }
                else
                {
                    ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
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
    //GET : SuppliersController/Create
    public ActionResult Create()
    {
        return View();
    }
    
    //POST: SuppliersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(SuppliersModel suppliers)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(suppliers);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5041/api/Supplier/SaveSuppliers",contentString);
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
                    return View(suppliers);
                }
            }
            catch (HttpRequestException e)
            {
                ViewBag.Message = $"Error en la solicitud HTPP: {e.Message}";
                return View(suppliers);
            }
        }
    }
    //GET:SuppliersController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try{
            var response = await httpClient.GetAsync($"http://localhost:5041/api/Supplier/GetSupplierByID?id{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);
            
            if (suppliersGetResult != null && suppliersGetResult.success)
            {
                return View(suppliersGetResult.result);
            }
            else
            {
                ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
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
 

    // POST: SuppliersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, SuppliersModel suppliers)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(suppliers);
                var contentString = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response =
                    await httpClient.PutAsync($"http://localhost:5041/api/Supplier/UpdateSupplier?id={id}",
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
                    return View(suppliers);
                }
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Message = $"Error en la solicitud HTTP: {ex.Message}";
                return View(suppliers);
            }
        }
    }

    // GET: SuppliersController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        using (var httpClient = new HttpClient(this.HttpClientHandler))
        {
            try
            {
                var response = await httpClient.GetAsync($"http://localhost:5041/api/Supplier/GetSupplierByID?id{id}");
                response.EnsureSuccessStatusCode();
                var apiResponse = await response.Content.ReadAsStringAsync();
                var suppliersGetResult = JsonConvert.DeserializeObject<SuppliersGetResult>(apiResponse);

                if (suppliersGetResult != null && suppliersGetResult.success)
                {
                    return View(suppliersGetResult.result);
                }
                else
                {
                    ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
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
                var response = await httpClient.DeleteAsync($"http://localhost:5041/api/Supplier/DeleteSupplier?id={id}");
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
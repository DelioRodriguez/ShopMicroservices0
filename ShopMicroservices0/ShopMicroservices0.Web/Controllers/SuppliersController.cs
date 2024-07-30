using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;


namespace ShopMicroservices0.Web.Controllers;

public class SuppliersController : Controller
{
    private readonly ISupplierServices _supplierServices;

    public SuppliersController(ISupplierServices supplierServices)
    {
        _supplierServices = supplierServices;
    }

    public async Task<ActionResult> Index()
    {
        var supplierGetListResult = await _supplierServices.GetSuppliers();
        if (supplierGetListResult != null && supplierGetListResult.success)
        {
            return View(supplierGetListResult.result);
        }

        ViewBag.Message = supplierGetListResult?.message ?? "Error desconocido";
        return View();
    }

    public async Task<ActionResult> Details(int id)
    {
        var supplierGetResult = await _supplierServices.GetSupplierById(id);
        if (supplierGetResult != null && supplierGetResult.success)
        {
            return View(supplierGetResult.result);
        }

        ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
        return View();
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(SuppliersModel suppliers)
    {
        var result = await _supplierServices.CreateSupplier(suppliers);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return View(suppliers);
    }

    public async Task<ActionResult> Edit(int id)
    {
        var supplierGetResult = await _supplierServices.GetSupplierById(id);
        if (supplierGetResult != null && supplierGetResult.success)
        {
            return View(supplierGetResult.result);
        }

        ViewBag.Message = supplierGetResult?.message ?? "Error desconocido";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, SuppliersModel suppliers)
    {
        var result = await _supplierServices.UpdateSuppliers(id, suppliers);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return View(suppliers);
    }

    public async Task<ActionResult> Delete(int id)
    {
        var suppliersGetResult = await _supplierServices.GetSupplierById(id);
        if (suppliersGetResult != null && suppliersGetResult.success)
        {
            return View(suppliersGetResult.result);
        }

        ViewBag.Message = suppliersGetResult?.message ?? "Error desconocido";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        var result = await _supplierServices.DeleteSuppliers(id);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return RedirectToAction(nameof(Delete), new { id });
    }
}
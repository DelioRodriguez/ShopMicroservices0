using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;


namespace ShopMicroservices0.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoriesServices _categoriesServices;

    public CategoriesController(ICategoriesServices categoriesServices)
    {
        this._categoriesServices = categoriesServices;
    }

    public async Task<ActionResult> Index()
    {
        var categoriesGetList = await _categoriesServices.GetCategories();
        if (categoriesGetList != null && categoriesGetList.success)
        {
            return View(categoriesGetList.result);
        }

        ViewBag.Message = categoriesGetList?.message ?? "Error desconocido";
        return View();
    }


    public async Task<ActionResult> Details(int id)
    {
        var categoriesGetResult = await _categoriesServices.GetCategoriesById(id);
        if (categoriesGetResult != null && categoriesGetResult.success)
        {
            return View(categoriesGetResult.result);
        }

        ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
        return View();
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CategoriesModel categories)
    {
        var result = await _categoriesServices.CreateCategories(categories);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return View(categories);
    }

    public async Task<ActionResult> Edit(int id)
    {
        var categoriesGetResult = await _categoriesServices.GetCategoriesById(id);
        if (categoriesGetResult != null && categoriesGetResult.success)
        {
            return View(categoriesGetResult.result);
        }

        ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, CategoriesModel categories)
    {
        var result = await _categoriesServices.UpdateCategories(id, categories);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return View(categories);
    }

    public async Task<ActionResult> Delete(int id)
    {
        var categoriesGetResult = await _categoriesServices.GetCategoriesById(id);
        if (categoriesGetResult != null && categoriesGetResult.success)
        {
            return View(categoriesGetResult.result);
        }

        ViewBag.Message = categoriesGetResult?.message ?? "Error desconocido";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        var result = await _categoriesServices.DeleteCategories(id);
        if (result != null && result.success)
        {
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Message = result?.message ?? "Error desconocido";
        return RedirectToAction(nameof(Delete), new { id });
    }
}
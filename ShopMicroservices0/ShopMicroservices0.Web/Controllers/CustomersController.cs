using Microsoft.AspNetCore.Mvc;
using ShopMicroservices0.Web.IServices;
using ShopMicroservices0.Web.Models;


namespace ShopMicroservices0.Web.Controllers;

public class CustomersController : Controller
{
       private readonly ICustomerServices _customerService;

        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        public async Task<ActionResult> Index()
        {
            var customerGetListResult = await _customerService.GetCustomer();
            if (customerGetListResult != null && customerGetListResult.success)
            {
                return View(customerGetListResult.result);
            }
            ViewBag.Message = customerGetListResult?.message ?? "Error desconocido";
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var customerGetResult = await _customerService.GetCustomerById(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }
            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomersModel customer)
        {
            var result = await _customerService.CreateCustomer(customer);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(customer);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var customerGetResult = await _customerService.GetCustomerById(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }
            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomersModel customer)
        {
            var result = await _customerService.UpdateCustomer(id, customer);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(customer);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var customerGetResult = await _customerService.GetCustomerById(id);
            if (customerGetResult != null && customerGetResult.success)
            {
                return View(customerGetResult.result);
            }
            ViewBag.Message = customerGetResult?.message ?? "Error desconocido";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }

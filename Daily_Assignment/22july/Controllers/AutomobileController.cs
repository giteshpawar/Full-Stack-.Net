using Microsoft.AspNetCore.Mvc;
using AutomobileManagementSystem.Models;

namespace AutomobileManagementSystem.Controllers
{
    public class AutomobileController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                TempData["VehicleName"] = automobile.VehicleName;
                TempData["Brand"] = automobile.Brand;

                return RedirectToAction("Details", "Manufacturer");
            }

            return View(automobile);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using AutomobileManagementSystem.Models;

namespace AutomobileManagementSystem.Controllers
{
    public class ManufacturerController : Controller
    {
        public IActionResult Details()
        {
            ViewBag.VehicleName = TempData["VehicleName"];
            ViewBag.Brand = TempData["Brand"];

            return View(new Manufacturer());
        }

        [HttpPost]
        public IActionResult Details(Manufacturer manufacturer)
        {
            ViewBag.VehicleName = TempData["VehicleName"];
            ViewBag.Brand = TempData["Brand"];

            if (ModelState.IsValid)
            {
                return View("Success", manufacturer);
            }

            return View(manufacturer);
        }
    }
}
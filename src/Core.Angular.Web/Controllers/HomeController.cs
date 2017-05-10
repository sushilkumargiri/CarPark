using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.DTO;
using BL;
using Core.Angular.Web.ViewModel;

namespace Core.Angular.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarPark _carpark;

        public HomeController(ICarPark carpark)
        {
            _carpark = carpark;
        }
        public JsonResult Calculate(Vehicle vehicle)
        {
            return Json(_carpark.CalculateParkingFee(Vehicle.Map(vehicle)));
        }
        
        [HttpPost]
        public JsonResult CalculateNew([FromBody] Vehicle vehicle)
        {
            return Json(_carpark.CalculateParkingFee(Vehicle.Map(vehicle)));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

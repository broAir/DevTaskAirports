using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevTask.App.Models;
using DevTask.Services.Airports;

namespace DevTask.App.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IAirportsService AirportsService;

        public HomeController(IAirportsService airportsService)
        {
            AirportsService = airportsService;
        }
        
        public async Task<IActionResult> Index()
        {
            var airports = await AirportsService.GetAirports();
            HttpContext.Response.Headers["from-database"] = airports.FromCache.ToString();
            // convert to the viewmodel
            var model = new AirportsViewModel
            {
                Airports = Enumerable.Empty<AirportViewModel>()
            };
            return View(model);
        }

    }
}
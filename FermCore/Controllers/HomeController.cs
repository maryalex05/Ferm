using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FermCore.Models;
using FermCore.Service.Mongo;
using FermCore.DB.Model;
using Microsoft.AspNetCore.Authorization;

namespace FermCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoService _mongoService;
        public HomeController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var a = _mongoService.GetAll<AdModel>("ad");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

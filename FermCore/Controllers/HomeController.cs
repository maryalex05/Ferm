﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FermCore.Models;
using FermCore.Service.Mongo;
using FermCore.DB.Model;
using Microsoft.AspNetCore.Authorization;
using FermCore.Service.AD;

namespace FermCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IADService _mongoService;
        public HomeController(IADService mongoService)
        {
            _mongoService = mongoService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var a = _mongoService.GetAll();
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

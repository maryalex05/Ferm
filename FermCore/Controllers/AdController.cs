using FermCore.Service.AD;
using FermCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.Controllers
{
    public class AdController : Controller
    {
        private readonly IADService _aDService;

        public AdController(IADService aDService)
        {
            _aDService = aDService;
        }

        [HttpGet]
        public IActionResult AllAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddingAd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddingAd(AdViewModel adViewModel)
        {

            return View(adViewModel);
        }


    }
}

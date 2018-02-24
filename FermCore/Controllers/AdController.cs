using FermCore.DB.Model;
using FermCore.Service.AD;
using FermCore.Service.User;
using FermCore.ViewModels;
using FermCore.ViewModels.AD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.Controllers
{
    public class AdController : Controller
    {
        private readonly IADService _aDService;
        private readonly IUserService _userService;

        public AdController(IADService aDService,
            IUserService userService)
        {
            _aDService = aDService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult AllAd()
        {
            var ads = _aDService.GetAll();
            return View(ads);
        }

        [HttpGet]
        public IActionResult ViewAd(string adId)
        {
            var ad = _aDService.GetById(ObjectId.Parse(adId));
            return View(ad);
        }

        [HttpPost]
        public IActionResult AllAd(string adType, int page)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddingAd()
        {
            var adTypes = _aDService.GetAllAdType().Select(x => new { Id = x.Id.ToString(), Name = x.Name});
            ViewBag.AdTypes = new SelectList(adTypes, "Id", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddingAd(AdViewModel adViewModel)
        {
            if(ModelState.IsValid)
            {
                AdModel ad = new AdModel { Name = adViewModel.Name,
                    AdText = adViewModel.Text,
                    AdTypeId = ObjectId.Parse(adViewModel.AdTypesId)
                };

                var user = _userService.GetByEmail(User.Identity.Name);

                _aDService.Insert(ad, user.Id);
            }

            var adTypes = _aDService.GetAllAdType().Select(x => new { Id = x.Id.ToString(), Name = x.Name });
            ViewBag.AdTypes = new SelectList(adTypes, "Id", "Name");

            return View(adViewModel);
        }

        [HttpGet]
        public IActionResult AddingAdType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddingAdType(AdTypeView adType)
        {
            AdType ad = new AdType
            {
                Name = adType.Name
            };

            _aDService.InsertAdType(ad);

            return View(adType);
        }


    }
}

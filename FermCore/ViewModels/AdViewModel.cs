using FermCore.DB.Model;
using FermCore.Service.AD;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.ViewModels
{
    public class AdViewModel
    {
        [Required(ErrorMessage = "Не указанно название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public List<SelectListItem> AdTypes { get; set; }


        private readonly IADService _aDService;
        public AdViewModel(IADService aDService)
        {
            _aDService = aDService;
            var ads = _aDService.GetAllAdType();

            AdTypes = new List<SelectListItem>();

            foreach (var ad in ads)
            {               
                AdTypes.Add(new SelectListItem {
                    Text = ad.Name,
                    Value  = ad.Id.ToString()
                });
            }            
        }



    }
}

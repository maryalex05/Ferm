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

        [Required(ErrorMessage = "Не указан текст")]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Не указан тип")]
        [Display(Name = "тип")]
        public string AdTypesId { get; set; }

    }
}

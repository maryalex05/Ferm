using FermCore.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FermCore.ViewModels.AD
{
    public class AdTypeView
    {
        [Required(ErrorMessage = "Не указанно название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

    }
}

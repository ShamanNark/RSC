﻿using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterUniversityViewModel : RegisterViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        [Required]
        [Display(Name = "Форма ООВО")]
        public string UniversityForm { get; set; }
        [Required]
        [Display(Name = "Полное наименование образовательной организации ")]
        public string UniversityName { get; set; }
        [Required]
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }
    }
}
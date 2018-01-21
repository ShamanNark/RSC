using Microsoft.AspNetCore.Http;
using RSC.Controllers.Models;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterUniversityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан факс")]
        [Display(Name = "Факс")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Не указана форма ООВО")]
        [Display(Name = "Форма ООВО")]
        public string UniversityForm { get; set; }
        [Required(ErrorMessage = "Не указано наименование обр. орг.")]
        [Display(Name = "Полное наименование образовательной организации ")]
        public int UniversityDataId { get; set; }
        [Required(ErrorMessage = "Не указан рабочий телефон")]
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }
        [Required(ErrorMessage = "Не указан Веб-сайт")]
        [Display(Name = "Веб-сайт ООВО")]
        public string UniversityWebSite { get; set; }
        [Required(ErrorMessage = "Не указана доверенность")]
        [Display(Name = "Доверенность *")]
        public IFormFile PowerOfAttorneyFile { get; set; }

        [Required]
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
    }
}

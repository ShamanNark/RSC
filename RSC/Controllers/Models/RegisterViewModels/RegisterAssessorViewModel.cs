using RSC.Controllers.Models;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterAssessorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название организации")]
        [Required(ErrorMessage = "Не указано название организации")]
        public string Organisation { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Не указана Должность")]
        public string OrganisationPosition { get; set; }

        [Required(ErrorMessage = "Не указан рабочий телефон эксперта")]
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }

        [Display(Name = "Опыт участия в экспертной комиссии ")]
        public bool ExperienceOfParticipation { get; set; }

        [Required]
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
    }
}

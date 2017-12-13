using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterAssessorViewModel : RegisterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано фамилия эксперта")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано имя эксперта")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано отчество эксперта")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указано место работы эксперта")]
        [Display(Name = "место работы")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Не указана должность эксперта")]
        [Display(Name = "Должность")]
        public string JobPosition { get; set; }

        [Required(ErrorMessage = "Не указан рабочий телефон эксперта")]
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }

        [Display(Name = "Опыт участия в экспертной комиссии ")]
        public bool ExperienceOfParticipation { get; set; }
    }
}

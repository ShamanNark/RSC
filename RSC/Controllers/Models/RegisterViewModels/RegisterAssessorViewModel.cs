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
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "место работы")]
        public string Job { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string JobPosition { get; set; }
        [Required]
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }
        [Required]
        [Display(Name = "Опыт участия в экспертной комиссии ")]
        public bool ExperienceOfParticipation { get; set; }
    }
}

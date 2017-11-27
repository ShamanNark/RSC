using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class StudentsCouncilViewModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

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
        [Display(Name ="Рабочий телефон")]
        public string JobPhone { get; set; }

        [Required]
        [Display(Name = "Мобильный телефон")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Required]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }

        [Required]
        [Display(Name = "Высшее оброзовательное учереждение")]
        public int EducationalOrganizationId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повторить пароль")]
        public string ConfirmPassword { get; set; }
    }
}

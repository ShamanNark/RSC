using RSC.Data.DbModels;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterStudentViewModel : RegisterViewModel
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
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Required]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        [Required]
        [Display(Name = "Образование")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Институт")]
        public int EducationalOrganizationId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}

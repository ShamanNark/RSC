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
        [Required(ErrorMessage = "Не указана фамилия студента")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано имя студента")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано отчество студента")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения студента")]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Не указан пол студента")]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Не указан регион")]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Не указано высшее оброзование")]
        [Display(Name = "Образование")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Не указан институт")]
        [Display(Name = "Институт")]
        public int UniversityDataId { get; set; }
    }
}

using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterStudentCouncilViewModel : RegisterViewModel
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
        [Display(Name = "Наименование образовательной организации")]
        public int EducationalOrganizationIdCouncil { get; set; }
        [Required]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
    }
}

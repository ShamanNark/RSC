using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class CO
    {
        [Required]
        [Display(Name="Отчество")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string EducationalEmail { get; set; }
    }
}

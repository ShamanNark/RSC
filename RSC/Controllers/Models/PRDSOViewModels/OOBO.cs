using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class OOBO
    {
        [Required]
        [Display(Name = "Приках об утверждении (назначении) ректора")]
        public string OrderApprovalheadOOVO { get; set; }

        [Required]
        [Display(Name = "Отчетсво")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Фамимлия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name ="Должность")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Рабочий телефон")]
        public string WorkPhone { get; set; }

        [Required]
        [Display(Name = "Мобильный телефон")]
        public string Fax { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
    }
}

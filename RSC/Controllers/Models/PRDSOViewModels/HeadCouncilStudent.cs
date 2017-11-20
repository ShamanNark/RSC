using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class HeadCouncilStudent
    {
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Рабочий телефон")]
        public string WorkPhone { get; set; }

        [Required]
        [Display(Name = "Мобильный телефон")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Приказ о создании Совета обучающихся")]
        public string ReportConferenceSO { get; set; }

        [Required]
        [Display(Name = "Протокол отчетно-выборной конференции СО")]
        public string OrderCouncilLearners { get; set; }

        [Required]
        [Display(Name = "Протокол СО об утверждении Программы развития деятельности студенческих объединений ООВО")]
        public string DevelopmentOfActivitiesStudents { get; set; }

    }
}

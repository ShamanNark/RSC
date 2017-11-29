using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class BankDetails
    {
        [Required]
        [Display(Name = "ИНН банка")]
        public string INN { get; set; }

        [Required]
        [Display(Name = "КПП банка")]
        public string KPP { get; set; }

        [Required]
        [Display(Name = "БИК")]
        public string BIK { get; set; }

        [Required]
        [Display(Name = "Наименование обслуживающего банка")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "Корреспондентский счет")]
        public string CorrespondentAccount { get; set; }

        [Required]
        [Display(Name = "Расчетный счет")]
        public string СalculatedAccount { get; set; }
    }
}

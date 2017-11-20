using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class CategoryOfProgramm
    {
        #region Program 

        [Required]
        [Display(Name = "Категория программы*")]
        public string CategoryOfProgram { get; set; }
        [Display(Name = "Объем запрашиваемой дополнительной субсидии из федерального бюджета на реализацию мероприятий (проектов) ПРДСО")]
        public decimal AdditionalSubsidyFromFederal { get; set; }
        [Display(Name = "Объем собственных и привлеченных средств, направленных на реализацию мероприятий (проектов) ПРДСО")]
        public decimal VolumeOwnAttractedAimed { get; set; }
        [Display(Name = "Количество задействованных в реализации мероприятий Программы обучающихся по очной форме обучения")]
        public int CountStudents { get; set; }

        #endregion
    }
}

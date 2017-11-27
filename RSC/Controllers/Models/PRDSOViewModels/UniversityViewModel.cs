using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class UniversityViewModel
    {
        public int Id { get; set; }
        
        [Display(Name="")]
        public string UniversityForm { get; set; }
        
        [Display(Name="Фамилия*")]
        public string MiddleName { get; set; }
        
        [Display(Name ="Имя*")]
        public string Name { get; set; }
        
        [Display(Name ="Отчество*")]
        public string Surname { get; set; }
        
        [Display(Name = "Рабочий номер*")]
        public string JobPhoneNumber { get; set; }

        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Display(Name = "Регион")]
        public int RegionId { get; set; }

        [Display(Name = "Университет")]
        public int UniversityDataId { get; set; }

        
        public string ApplicationUserId { get; set; }
    }
}

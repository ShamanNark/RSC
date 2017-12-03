using Microsoft.AspNetCore.Http;
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
        public int UniversityDataId { get; set; }
        [Required]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        [Required]
        [Display(Name = "Приказ создания совета обучающихся *")]
        public IFormFile OrderCreationCouncilOfLearnersFile { get; set; }
        [Required]
        [Display(Name = "Протокол отчетно-выборной конфернеции СО *")]
        public IFormFile ConferenceProtocolFile { get; set; }
        [Required]
        [Display(Name = "Протокол СО об утверждении Программы развитиядеятельности студенческих объединений ООВО *")]
        public IFormFile ProtocolApprovalStudentAssociationsFile { get; set; }
    }
}

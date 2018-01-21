using Microsoft.AspNetCore.Http;
using RSC.Controllers.Models;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterStudentCouncilViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано наименование образовательной организации")]
        [Display(Name = "Наименование образовательной организации")]
        public int UniversityDataId { get; set; }

        [Required(ErrorMessage = "Не Указан рабочий телефон")]
        [Display(Name = "Рабочий телефон")]
        public string JobPhone { get; set; }

        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Не указан приказ создания совета обучающихся")]
        [Display(Name = "Приказ создания совета обучающихся *")]
        public IFormFile OrderCreationCouncilOfLearnersFile { get; set; }

        [Required(ErrorMessage = "Не указан протокол отчетно-выборной конференции СО")]
        [Display(Name = "Протокол отчетно-выборной конфернеции СО *")]
        public IFormFile ConferenceProtocolFile { get; set; }

        [Required(ErrorMessage = "Не указан протокол СО об утверждении программы")]
        [Display(Name = "Протокол СО об утверждении Программы развитиядеятельности студенческих объединений ООВО *")]
        public IFormFile ProtocolApprovalStudentAssociationsFile { get; set; }

        [Required]
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
    }
}

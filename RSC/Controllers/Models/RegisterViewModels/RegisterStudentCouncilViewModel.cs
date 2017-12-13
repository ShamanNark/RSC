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

        [Required(ErrorMessage = "Не указано фамилия СО")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано имя СО")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано отчество СО")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указано наименование образовательной организации")]
        [Display(Name = "Наименование образовательной организации")]
        public int UniversityDataId { get; set; }

        [Required(ErrorMessage = "Не указан регион")]
        [Display(Name = "Регион")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Не указан приказ создания совета обучающихся")]
        [Display(Name = "Приказ создания совета обучающихся *")]
        public IFormFile OrderCreationCouncilOfLearnersFile { get; set; }

        [Required(ErrorMessage = "Не указан протокол отчетно-выборной конференции СО")]
        [Display(Name = "Протокол отчетно-выборной конфернеции СО *")]
        public IFormFile ConferenceProtocolFile { get; set; }

        [Required(ErrorMessage = "Не указан протокол СО об утверждении программы")]
        [Display(Name = "Протокол СО об утверждении Программы развитиядеятельности студенческих объединений ООВО *")]
        public IFormFile ProtocolApprovalStudentAssociationsFile { get; set; }
    }
}

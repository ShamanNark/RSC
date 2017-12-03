using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class StudentsCouncilViewModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        
        [Display(Name = "Фамилия *")]
        public string Surname { get; set; }
                
        [Display(Name = "Имя *")]
        public string Name { get; set; }

        [Display(Name = "Отчество *")]
        public string MiddleName { get; set; }
        
        [Display(Name ="Рабочий телефон *")]
        [DataType(DataType.PhoneNumber)]
        public string JobPhone { get; set; }
        
        [Display(Name = "Мобильный телефон *")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
        
        [Display(Name = "Факс")]
        public string Fax { get; set; }
        
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        
        [Display(Name = "Высшее оброзовательное учереждение")]
        public int UniversityDataId { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email *")]
        public string Email { get; set; }
        
        [Display(Name = "Пароль *")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Повторить пароль *")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Протокол отчетно-выборной конференции СО *")]
        public IFormFile ConferenceProtocolFile { get; set; }

        [Display(Name = "Приказ о создании Совета обучающихся *")]
        public IFormFile OrderCreationCouncilOfLearnersFile { get; set; }

        [Display(Name = "Протокол СО об утверждении Программы развития деятельности студенческих объединений ООВО *")]
        public IFormFile ProtocolApprovalStudentAssociationsFile { get; set; }

    }
}

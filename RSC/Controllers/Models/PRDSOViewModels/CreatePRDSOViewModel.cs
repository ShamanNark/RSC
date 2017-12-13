using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class CreatePRDSOViewModel
    {
        #region OOVO Details

        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан ОГРН")]
        [Display(Name = "ОГРН *")]
        public string OGRN { get; set; }

        [Required(ErrorMessage = "Не указан ИНН")]
        [Display(Name = "ИНН *")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Не указано ОКПО")]
        [Display(Name = "ОКПО *")]
        public string OKPO { get; set; }

        [Required(ErrorMessage = "Не указано КПП")]
        [Display(Name = "КПП *")]
        public string KPP { get; set; }

        [Required(ErrorMessage = "Не указан юридический адрес")]
        [Display(Name = "Юридический адрес *")]
        [DataType(DataType.Text)]
        public string UrAddress { get; set; }

        [Required(ErrorMessage = "Не указан почтовый адрес")]
        [Display(Name = "Почтовый адрес *")]
        public string MailAddress { get; set; }
        
        [Display(Name = "Web-сайт образовательной организации")]
        [DataType(DataType.Url)]
        public string WebSite { get; set; }
        
        [Required(ErrorMessage = "Не указан ЕГРЮЛ")]
        [Display(Name = "ЕГРЮЛ *")]
        public IFormFile EGRULfile { get; set; }

        [Display(Name = "Численность обучающихся по очной форме обучения, включая филиалы, чел.")]
        public int StudentsCount { get; set; }

        #endregion

        #region Heads OOVO

        #region Master head
        [Required(ErrorMessage = "Не указана фамилия руководителя")]
        [Display(Name = "Фамилия *")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Не указано имя руководителя")]
        [Display(Name = "Имя *")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не указано отчество руководителя")]
        [Display(Name = "Отчество *")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указана должность руководителя")]
        [Display(Name = "Должность *")]
        public string Position { get; set; }
        
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Не указан телефон руководителя")]
        [Display(Name = "Телефон *")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNummber { get; set; }
        
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Не указан приказ об утверждении руководителя")]
        [Display(Name = "Приказ об утверждении (назначении) ректора *")]
        public IFormFile OderApprovalRectorFile { get; set; }

        #endregion
        
        public UniversityViewModel UniversityViewModel { get; set; }


        public int StudentsCouncilId { get; set; }        
        public StudentsCouncilViewModel StudentsCouncilViewModel { get; set; }

        #endregion

        #region Billing infomation


        [Required(ErrorMessage = "Не указан ИНН")]
        [Display(Name = "ИНН банка *")]
        public string BankINN { get; set; }


        [Required(ErrorMessage = "Не указан КПП")]
        [Display(Name = "КПП банка *")]
        public string BankKPP { get; set; }


        [Required(ErrorMessage = "Не указано наименование обслуживающего банка")]
        [Display(Name = "Наименование обслуживающего банка *")]
        public string BankName { get; set; }


        [Required(ErrorMessage = "Не указан расчетный счет")]
        [Display(Name = "Расчетный счет *")]
        [DataType(DataType.CreditCard)]
        public string CheckingAccount { get; set; }


        [Required(ErrorMessage = "Не указан корреспондентский счет")]
        [Display(Name = "Корреспондентский счет *")]
        [DataType(DataType.CreditCard)]
        public string CorrespondentAccount { get; set; }


        [Required(ErrorMessage = "Не указано БИК")]
        [Display(Name = "Код БИК")]
        public string BICCode { get; set; }
        #endregion

        #region Additional info
        
        public SelectList UniversityDatas { get; set; }

        public SelectList Regions { get; set; }

        public bool CreateStudentCouncil { get; set; }

        public List<StudentsCouncilViewModel> StudentCouncils { get; set; }

        #endregion
    }
}

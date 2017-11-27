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

        [Required]
        [Display(Name = "ОГРН")]
        public string OGRN { get; set; }


        [Required]
        [Display(Name = "ИНН")]
        public string INN { get; set; }


        [Required]
        [Display(Name = "ОКПО")]
        public string OKPO { get; set; }


        [Required]
        [Display(Name = "КПП")]
        public string KPP { get; set; }


        [Required]
        [Display(Name = "Юридический адрес")]
        public string UrAddress { get; set; }


        [Required]
        [Display(Name = "Почтовый адрес")]
        public string MailAddress { get; set; }


        [Required]
        [Display(Name = "Web-сайт образовательной организации")]
        public string WebSite { get; set; }


        [Required]
        [Display(Name = "ЕГРЮЛ ")]
        public FileModel EGRUL { get; set; }


        [Required]
        [Display(Name = "Численность обучающихся по очной форме обучения, включая филиалы, чел.")]
        public int StudentsCount { get; set; }

        #endregion

        #region Heads OOVO

        #region Master head
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
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Приказ об утверждении (назначении) ректора ")]
        public FileModel OrderApprovalRector { get; set; }

        #endregion
        
        public UniversityViewModel University { get; set; }
                
        public StudentsCouncilViewModel StudentsCouncil { get; set; }

        #endregion

        #region Billing infomation


        [Required]
        [Display(Name = "ИНН банка")]
        public string BankINN { get; set; }


        [Required]
        [Display(Name = "КПП банка")]
        public string BankKPP { get; set; }


        [Required]
        [Display(Name = "Наименование обслуживающего банка")]
        public string BankName { get; set; }


        [Required]
        [Display(Name = "Расчетный счет")]
        public string CheckingAccount { get; set; }


        [Required]
        [Display(Name = "Корреспондентский счет")]
        public string CorrespondentAccount { get; set; }


        [Required]
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

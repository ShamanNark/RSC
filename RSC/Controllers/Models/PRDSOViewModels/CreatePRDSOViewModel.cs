using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class CreatePRDSOViewModel
    {
        #region information

        [Required]
        [Display(Name = "Регион *")]
        public int RegionId { get; set; }

        [Required]
        [Display(Name = "Форма ОВВО *")]
        public string OOBO { get; set; }

        [Required]
        [Display(Name = "Сокращенное наименование оброзовательной оргонизации *")]
        public string UniversityShortName { get; set; }

        [Required]
        [Display(Name = "Полное наименование образовательной организации *")]
        public int UniversityLongName { get; set; }
        public SelectList ListUniversityLongName { get; set; }

        [Required]
        [Display(Name = "Наименование образовательной оргоназиции на английском языке")]
        public string UniversityEngLongName { get; set; }

        [Required]
        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        [Required]
        [Display(Name = "Почтовый адрес")]
        public string MailingAddress { get; set; }

        [Required]
        [Display(Name = "Веб-сайт")]
        public string WebSite { get; set; }

        [Required]
        [Display(Name = "ОГРН *")]
        public string OGRN { get; set; }

        [Required]
        [Display(Name = "ИНН *")]
        public string INN { get; set; }

        [Required]
        [Display(Name = "КПП *")]
        public string KPP { get; set; }

        [Required]
        [Display(Name = "ОКПО *")]
        public string OKPO { get; set; }

        [Required]
        [Display(Name = "ЕГРЮЛ *")]
        public string EGRUL { get; set; }

        #endregion

        #region leader

        [Required]
        [Display(Name = "Руководитель ООВО")]
        public OOBO Leaeder { get; set; }

        #endregion

        #region Head of the structural unit for educational work, supervising the Board of Learners

        [Required]
        [Display(Name = "Руководитель структурного подразделения по воспитательной работе, курирующий Совет обучающихся")]
        public CO CouncilStudents { get; set; }

        #endregion

        #region Head of the Board of Learners

        [Required]
        [Display(Name = "Руководитель Совета обучающихся")]
        public HeadCouncilStudent HeadCouncilStudent { get;set;}

        #endregion

        #region BankDetails

        [Required]
        [Display(Name = "Банковские реквизиты")]
        public BankDetails BankDetails { get; set; }

        #endregion

        #region Program 

        List<CategoryOfProgramm> CategoriesOfProgramm { get; set; }

        #endregion

        #region Evenets 
        
        List<Event> Events { get; set; }

        #endregion
    }
}

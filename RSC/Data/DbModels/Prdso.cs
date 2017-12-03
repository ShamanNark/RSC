using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Prdso
    {

        #region OOVO Details

        public int Id { get; set; }

        [Display(Name = "ОГРН")]
        public string OGRN { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "ОКПО")]
        public string OKPO { get; set; }

        [Display(Name = "КПП")]
        public string KPP { get; set; }

        [Display(Name = "Юридический адрес")]
        public string UrAddress { get; set; }

        [Display(Name = "Почтовый адрес")]
        public string MailAddress { get; set; }

        [Display(Name = "Web-сайт образовательной организации")]
        public string WebSite { get; set; }

        [Display(Name = "ЕГРЮЛ ")]
        public int EGRULId { get; set; }
        [ForeignKey("EGRULId")]
        public virtual FileModel EGRUL { get; set; }

        [Display(Name = "Численность обучающихся по очной форме обучения, включая филиалы, чел.")]
        public int StudentsCount { get; set; }

        public bool UniversityApproved { get; set; } = false;

        public bool StudentCouncilApproved { get; set; } = false;
        
        [Display(Name = "Статус")]
        public int StatusId { get; set; }
        public PrdsoStatus Status { get; set; }

        public string PrdsoStatusComment { get; set; }

        #endregion

        #region Heads OOVO

        #region Master head

        [Display(Name="Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Факс")]
        public string Fax { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Приказ об утверждении (назначении) ректора ")]
        public int OderApprovalRectorId { get; set; }
        [ForeignKey("OderApprovalRectorId")]
        public virtual FileModel OrderApprovalRector { get; set; }

        #endregion

        public int UniversityId { get; set; }
        public virtual University University { get; set; }

        public int StudentsCouncilId { get; set; }
        public virtual StudentsCouncil StudentsCouncil { get; set; }

        #endregion

        #region Billing infomation

        [Display(Name = "ИНН банка")]
        public string BankINN { get; set; }

        [Display(Name = "КПП банка")]
        public string BankKPP { get; set; }

        [Display(Name = "Наименование обслуживающего банка")]
        public string BankName { get; set; }

        [Display(Name = "Расчетный счет")]
        public string CheckingAccount { get; set; }

        [Display(Name = "Корреспондентский счет")]
        public string CorrespondentAccount { get; set; }

        [Display(Name = "Код БИК")]
        public string BICCode { get; set; }

        #endregion
                        
        public virtual List<Event> Events { get; set; }
    }
}

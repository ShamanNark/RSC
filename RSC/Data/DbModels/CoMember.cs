using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class CoMember
    {
        public int Id { get; set; }
        [Display(Name = "СО")]
        public int StudentsCouncilId { get; set; }
        public virtual StudentsCouncil StudentsCouncil { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string MidleName { get; set; }
        [Display(Name = "Телефон рабочий")]
        public string JobPhoneNumber { get; set; }
        [Display(Name = "Мобильный телефон")]
        public string MobilePhoneNumber { get; set; }
    }
}

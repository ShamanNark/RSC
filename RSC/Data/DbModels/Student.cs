using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        [Display(Name = "Степень образования")]
        public Degrees CategoryId { get; set; }

        public virtual Region Region {get; set;}

        public int UniversityDataId { get; set; }
        public virtual UniversityData UniversityData { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } 
    }
}

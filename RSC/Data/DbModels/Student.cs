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
        [Display(Name = "Степень образования")]
        public Degrees CategoryId { get; set; }
        [Display(Name = "Университет")]
        public int UniversityDataId { get; set; }
        public virtual UniversityData UniversityData { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } 
    }
}

using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class University
    {
        public int Id { get; set; }
        public string UniversityForm { get; set; }
        public string UniversityWebSite { get; set; }
        [Display(Name = "Рабочий телефон")]
        public string JobPhoneNumber { get; set; }
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        public int PowerOfAttorneyId { get; set; }
        [ForeignKey("PowerOfAttorneyId")]
        public virtual FileModel PowerOfAttorney { get; set; }

        public int UniversityDataId { get; set; }            
        public virtual UniversityData UniversityData { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

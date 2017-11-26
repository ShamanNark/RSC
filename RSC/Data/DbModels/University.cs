using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class University
    {
        public int Id { get; set; }
        public string UniversityForm { get; set; }
        public string UniversityName { get; set; }
        public string MiddleName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JobPhoneNumber { get; set; }
        public string Fax { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public int EducationalOrganizationId { get; set; }
        [ForeignKey("EducationalOrganizationId")]
        public virtual UniversityData UniversityData { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

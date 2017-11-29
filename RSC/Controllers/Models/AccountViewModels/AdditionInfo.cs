using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.AccountViewModels
{
    public class AdditionInfo
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        //student
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int RegionId { get; set; }
        public Degrees CategoryId { get; set; }
        public int EducationalOrganizationId { get; set; }
        public string EducationalOrganizationName { get; set; }
        //assessor
        public string Job { get; set; }
        public string JobPosition { get; set; }
        public string JobPhoneNumber { get; set; }
        public bool ExperienceOfParticipation { get; set; }
        //studentcouncil
        public string EducationalOrganization { get; set; }
        //university
        public string UniversityForm { get; set; }
        public string UniversityName { get; set; }
        //public string JobPhoneNumber { get; set; }
    }
}

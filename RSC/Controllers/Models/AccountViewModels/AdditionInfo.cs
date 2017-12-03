using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RSC.Controllers.Models.AccountViewModels
{
    public class AdditionInfo
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Регион")]
        public Region Region { get; set; }

        //student
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        public int RegionId { get; set; }
        public Degrees CategoryId { get; set; }
        public int EducationalOrganizationId { get; set; }
        [Display(Name = "Название ООВО")]
        public string EducationalOrganizationName { get; set; }
        
        //assessor

        public string Job { get; set; }
        public string JobPosition { get; set; }
        public string JobPhoneNumber { get; set; }
        public bool ExperienceOfParticipation { get; set; }

        //studentcouncil
        
        public int Id { get; set; }
        public string JobPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public FileModel ConferenceProtocol { get; set; }
        public FileModel OrderCreationCouncilOfLearners { get; set; }
        public FileModel ProtocolApprovalStudentAssociations { get; set; }
        [Display(Name="Университет")]
        public UniversityData UniversityData { get; set; }

        //university
        public string UniversityForm { get; set; }
        [Display(Name = "Название ООВО")]
        public string UniversityName { get; set; }
        //public string JobPhoneNumber { get; set; }
    }
}

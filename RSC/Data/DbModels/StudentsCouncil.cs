using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class StudentsCouncil
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string JobPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }

        public int ConferenceProtocolId { get; set; }
        [ForeignKey("ConferenceProtocolId")]
        public virtual FileModel ConferenceProtocol { get; set; }

        public int OrderCreationCouncilOfLearnersId { get; set; }
        [ForeignKey("OrderCreationCouncilOfLearnersId")]
        public virtual FileModel OrderCreationCouncilOfLearners { get; set; }

        public int ProtocolApprovalStudentAssociationsId { get; set; }
        [ForeignKey("ProtocolApprovalStudentAssociationsId")]
        public virtual FileModel ProtocolApprovalStudentAssociations { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public int EducationalOrganizationId { get; set; }
        [ForeignKey("EducationalOrganizationId")]
        public virtual UniversityData University { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

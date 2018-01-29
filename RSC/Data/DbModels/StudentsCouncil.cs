using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class StudentsCouncil
    {
        public int Id { get; set; }
        [Display(Name = "Рабочий телефон")]
        public string JobPhone { get; set; }
        [Display(Name = "Факс")]
        public string Fax { get; set; }

        public int? ConferenceProtocolId { get; set; }
        [ForeignKey("ConferenceProtocolId")]
        public virtual FileModel ConferenceProtocol { get; set; }

        public int? OrderCreationCouncilOfLearnersId { get; set; }
        [ForeignKey("OrderCreationCouncilOfLearnersId")]
        public virtual FileModel OrderCreationCouncilOfLearners { get; set; }

        public int? ProtocolApprovalStudentAssociationsId { get; set; }
        [ForeignKey("ProtocolApprovalStudentAssociationsId")]
        public virtual FileModel ProtocolApprovalStudentAssociations { get; set; }

        public int UniversityDataId { get; set; }
        public virtual UniversityData UniversityData { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

using RSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Assessor
    {
        public int Id { get; set; }

        [Display(Name = "Рабочий телефон")]
        public string JobPhoneNumber { get; set; }

        [Display(Name = "Есть опыт подобной практики")]
        public bool ExperienceOfParticipation { get; set; }

        [Display(Name = "Организация")]
        public string Organisation { get; set; }

        [Display(Name = "Должность")]
        public string OrganisationPosition { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

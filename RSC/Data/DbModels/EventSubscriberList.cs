using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSC.Models;

namespace RSC.Data.DbModels
{
    public class EventSubscriberList
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PublicEventInformationId { get; set; }
        public virtual PublicEventInformation PublicEventInformation { get; set; }
    }
}

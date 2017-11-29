using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.ProfileViewModels
{
    public class ProfileViewModel
    {
        public int PrdsoId { get; set; }
        public University University { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<Event> Events { get; set; }
    }
}

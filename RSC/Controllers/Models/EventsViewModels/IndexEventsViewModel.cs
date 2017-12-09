using RSC.Data.DbModels;
using RSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.EventsViewModels
{
    public class IndexEventsViewModel
    {
        public List<RowEventViewModel> Events { get; set; }
        public List<EventState> EventStates { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}

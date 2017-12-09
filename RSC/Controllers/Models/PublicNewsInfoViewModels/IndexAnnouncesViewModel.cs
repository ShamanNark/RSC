using RSC.Data.DbModels;
using RSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PublicNewsInfoViewModels
{
    public class IndexAnnouncesViewModel
    {
        public int SelectedEventDirectionId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public List<СellAnnonceViewModel> Events { get; set; }
        public List<EventDirection> EventDirections { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public IndexAnnouncesViewModel()
        {
            Events = new List<СellAnnonceViewModel>();
            EventDirections = new List<EventDirection>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.EventsViewModels
{
    public class RowEventViewModel
    {
        public int Id { get; set; }
        public string NameEvent { get; set; }
        public string UniversityShortName { get; set; } 
        public DateTime CreateDateTime { get; set; } 
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
    }
}

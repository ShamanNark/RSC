using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PublicNewsInfoViewModels
{
    public class СellAnnonceViewModel
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public string NameEvent { get; set; }
        public string Adress { get; set; }
        public string Contacts { get; set; }
        public string TicketPrice { get; set; }
        public string SmallFotoPath { get; set; }
    }
}

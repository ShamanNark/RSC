using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RSC.Data.DbModels;

namespace RSC.Controllers.Models.EventsViewModels
{
    public class AdditionalEventInfoViewMovel
    {

        public IFormFile Foto { get; set; }
        public List<int> ApplicationUserIds { get; set; }
        public string EventSite { get; set; }
    }
}

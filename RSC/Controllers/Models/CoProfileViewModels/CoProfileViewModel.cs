using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.CoProfileViewModels
{
    public class CoProfileViewModel
    {
        public List<Data.DbModels.EventDirection> EventDirections { get; set; }
        public List<Data.DbModels.Event> Events { get; set; }
    }
}

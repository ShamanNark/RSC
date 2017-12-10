using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSC.Data.DbModels;

namespace RSC.Controllers.Models.CoProfileViewModels
{
    public class CoProfileViewModel
    {
        public StudentsCouncil StudentCouncil { get; set; }
        public List<Data.DbModels.EventDirection> EventDirections { get; set; }
        public List<Data.DbModels.Event> Events { get; set; }
        public List<CoPersonalFile> Files { get; set; }
    }
}

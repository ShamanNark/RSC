using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.EventsViewModels
{
    public class TargetIndicator
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int BasicValue { get; set; }
        public int PlannedValue { get; set; }
    }
}

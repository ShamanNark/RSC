using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class TargetIndicator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int BasicValue { get; set; }
        public int PlannedValue { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

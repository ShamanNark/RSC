using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Cost
    {
        public int Id { get; set; }
        public string DirectionOfCost { get; set; }
        public string Unit { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int AmountCost { get; set; }
        public string Note { get; set; }

        public int СostDivisionId { get; set; }
        public virtual CostDivision СostDivision { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class CostSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<СostDivision> CostDivisions { get; set; }
    }
}

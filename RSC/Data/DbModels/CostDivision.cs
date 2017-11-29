using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class CostDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CostSectionId { get; set; }
        public virtual CostSection CostSection { get; set; }
    }
}

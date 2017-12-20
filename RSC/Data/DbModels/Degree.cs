using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Degree
    {
        public int Id { get; set; }

        public int UniversityDataId { get; set; }
        public virtual UniversityData UniversityData { get; set; }

        public 
    }
}

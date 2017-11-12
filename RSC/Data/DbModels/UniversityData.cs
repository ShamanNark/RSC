using RSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RSC.Data.DbModels
{
    public class UniversityData 
    {
       
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string UniversityShortName { get; set; }
        public string UniversityName { get; set; }
        public string UniversityAddress { get; set; }
        public string UniversityWebSite { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

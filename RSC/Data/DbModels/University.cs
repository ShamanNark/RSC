﻿using RSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class University
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string UniversityForm { get; set; }
        public string UniversityName { get; set; }
        public string JobPhoneNumber { get; set; }

        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
using RSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RSC.Data.DbModels
{
    public class Region
    {

        public int Id { get; set; }
        public string RegionName { get; set; }
    }

}
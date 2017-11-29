using RSC.Models.NewsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class NewsRubric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ObjectNewsNewsRubric> ListObjectNewsNewsRubric { get; set; }

        public NewsRubric()
        {
            ListObjectNewsNewsRubric = new List<ObjectNewsNewsRubric>();
        }
    }
}

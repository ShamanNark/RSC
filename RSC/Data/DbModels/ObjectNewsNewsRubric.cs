using RSC.Models.NewsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class ObjectNewsNewsRubric
    {
        public int Id { get; set; }

        public int NewsRubricId { get; set; }
        public NewsRubric NewsRubric { get; set; }

        public int ObjectNewsId { get; set; }
        public ObjectNews ObjectNews { get; set; }
    }
}

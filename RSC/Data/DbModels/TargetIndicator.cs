using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class TargetIndicator
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }
        [Display(Name = "Базовое значение")]
        public int BasicValue { get; set; }
        [Display(Name = "Плановое значение")]
        public int PlannedValue { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

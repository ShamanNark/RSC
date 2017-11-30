using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Cost
    {
        public int Id { get; set; }
        [Display(Name= "Направление расходов*")]
        public string DirectionOfCost { get; set; }
        [Display(Name = "Единица измерения*")]
        public string Unit { get; set; }
        [Display(Name = "Количество*")]
        public int Count { get; set; }
        [Display(Name = "Цена за еденицу")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Объем расходов*")]
        public int AmountCost { get; set; }
        [Display(Name = "Примечание")]
        public string Note { get; set; }

        public int СostDivisionId { get; set; }
        public virtual CostDivision СostDivision { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}

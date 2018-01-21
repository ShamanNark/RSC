using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public enum Gender
    {
        [Display(Name = "Мужской")]
        Male,
        [Display(Name = "Женский")]
        Female
    }
}

using RSC.Controllers.Models;
using RSC.Data.DbModels;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class RegisterStudentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано высшее оброзование")]
        [Display(Name = "Образование")]
        public Degrees CategoryId { get; set; }
        [Required(ErrorMessage = "Не указан институт")]
        [Display(Name = "Институт")]
        public int UniversityDataId { get; set; }

        [Required]
        public ApplicationUserViewModel ApplicationUserViewModel { get; set; }
    }
}

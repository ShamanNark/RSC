using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Не указана электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повторить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Не указан основной телефоный номер")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public string ApplicationUserId { get; set; }
    }
}

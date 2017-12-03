using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.AccountViewModels
{
    public class ConfirmationUsersViewModel
    {
        public string Id { get; set; }            
        public string UserName { get; set; }            
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Статус")]
        public RSC.Models.ApplicationUserStatus Status { get; set; }
        public string AdditionInfoType { get; set; }
        public AdditionInfo AdditionInfo { get; set; }
    }
}

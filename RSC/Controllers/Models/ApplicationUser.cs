using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RSC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {   
        public ApplicationUserStatus Status { get; set; }
        public ApplicationUserTypes UserType { get; set; }
    }

    public enum ApplicationUserStatus
    {
        [Display(Name = "Ожидание")]
        Submitted,
        [Display(Name = "Подтверждено")]
        Approved,
        [Display(Name = "Отклонено")]
        Rejected
    }

    public enum ApplicationUserTypes
    {
        Assessor,
        Student,
        StudentCouncil,
        University
    }
}

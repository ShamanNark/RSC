using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RSC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUserStatus Status { get; set; }
    }

    public enum ApplicationUserStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}

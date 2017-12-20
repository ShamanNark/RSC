using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using RSC.Data.DbModels;

namespace RSC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Фотография")]
        public FileModel Avatar { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }        

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

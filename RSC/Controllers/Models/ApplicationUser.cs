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

        [Display(Name = "Фото")]
        public int? AvatarId { get; set; }
        public FileModel Avatar { get; set; }

        [Display(Name = "Пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Регион")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        [Display(Name = "Ссылка ВКонтакте")]
        public string VKLink { get; set; }
        [Display(Name = "Ссылка Facebook")]
        public string FacebookLink { get; set; }
        [Display(Name = "Ссылка Twitter")]
        public string TwitterLink { get; set; }
        [Display(Name = "Ссылка Instagram")]
        public string InstagramLink { get; set; }
        [Display(Name = "Ссылка Telegram")]
        public string TelegramLink { get; set; }

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

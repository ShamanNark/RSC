using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Data.DbModels;
using RSC.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models
{
    public class ApplicationUserViewModel : RegisterViewModel
    {
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Не указана отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Не указана имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Что то не так с фото")]
        public IFormFile AvatarFile { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Что то не так с пол")]
        public Gender Gender { get; set; }

        [Display(Name = "Регион")]
        [Required(ErrorMessage = "Не указан регион")]
        public int RegionId { get; set; }
        public SelectList Regions { get; set; }

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
    }
}

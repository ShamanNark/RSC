using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RSC.Data.DbModels;

namespace RSC.Controllers.Models.PublicNewsInfoViewModels
{
    public class PublicNewsInfoViewModel
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Display(Name = "Видеопрезентация/видеооткрытка на ресурсе видео хостинга")]
        [DataType(DataType.Url)]
        public string VideoLink { get; set; }

        [Display(Name = "Фото мероприятия для анонса")]
        public IFormFile FotoFile { get; set; }

        [Display(Name = "Фото мероприятия для главной страницы")]
        public IFormFile SmallFotoFile { get; set; }

        [Display(Name = "Сайт мероприятия (при наличии)")]
        [DataType(DataType.Url)]
        public string EventWebSite { get; set; }

        [Display(Name = "Наличие информации о мероприятии на сайте ООВО")]
        [DataType(DataType.Url)]
        public string OOVOWebSite { get; set; }

        [Display(Name = "Хештег")]
        public string EventHashTags { get; set; }

        [Display(Name = "Видео-эссе, ролики об этапах по подготовке мероприятия на ресурсе видеохостинга")]
        [DataType(DataType.Url)]
        public string VideoEsse { get; set; }

        [Display(Name = "Группа мероприятия ВКонтакте")]
        [DataType(DataType.Url)]
        public string VKGroup { get; set; }

        [Display(Name = "Группа мероприятия Facebook")]
        [DataType(DataType.Url)]
        public string FacebookGroup { get; set; }

        [Display(Name = "Страница мероприятия Instagram")]
        [DataType(DataType.Url)]
        public string InstagramGroup { get; set; }

        [Display(Name = "Отчетный фильм/ролик о мероприятии на ресурсе видео хостинга")]
        [DataType(DataType.Url)]
        public string ResultVideo { get; set; }

        [Display(Name = "Федеральные")]
        [DataType(DataType.Url)]
        public string FederalSMI { get; set; }

        [Display(Name = "Региональные")]
        [DataType(DataType.Url)]
        public string RegionalSMI { get; set; }

        [Display(Name = "Окружные")]
        [DataType(DataType.Url)]
        public string DistricSMI { get; set; }

        [Display(Name = "Студенческие")]
        [DataType(DataType.Url)]
        public string StudentSMI { get; set; }

    }
}

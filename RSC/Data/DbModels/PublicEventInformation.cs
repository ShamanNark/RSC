using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class PublicEventInformation
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [Display(Name = "Информация о мероприятии")]
        public string TextForDetailsView { get; set; }

        [Display(Name = "Видеопрезентация/видеооткрытка на ресурсе видео хостинга")]
        [DataType(DataType.Url)]
        public string VideoLink { get; set; } 

        [Display(Name = "Фото мероприятия для анонса")]
        public int FotoId { get; set; }
        public virtual FileModel Foto { get; set; }

        [Display(Name = "Фото мероприятия для главной страницы")]
        public int SmallFotoId { get; set; }
        public virtual FileModel SmallFoto { get; set; }

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
        
        [Display(Name = "Положительные")]
        public int Likes { get; set; }

        [Display(Name = "Отрицательные")]
        public int DisLikes { get; set; }
    }
}

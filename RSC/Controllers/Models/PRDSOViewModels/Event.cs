using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.PRDSOViewModels
{
    public class Event
    {
        [Required]
        [Display(Name = "Лот")]
        public EventType EventType { get; set; }

        [Required]
        [Display(Name = "Масштаб мероприятия *")]
        public int scaleOfEvent { get; set; }

        [Required]
        [Display(Name = "Направление мероприятия *")]
        public string EventDirection { get; set; }

        [Required]
        [Display(Name = "Наименование мероприятия *")]
        public string NameOfEvent { get; set; }

        [Required]
        [Display(Name = "Цель мероприятия и его краткое содержание *")]
        public string AimofEvent { get; set; }

        [Required]
        [Display(Name = "Ожидаемые эффекты от реализации мероприяти *")]
        public string EffectsFromEvent { get; set; }

        [Required]
        [Display(Name = "Перечень субъектов РФ, из образовательных организаций которых будут принимать участие *")]
        public List<int> SubjectIds { get; set; }
        public SelectList ListOfSubjects { get; set; }

        [Required]
        [Display(Name = "Перечень стран - участников, из образовательных организаций которых будут принимать участие *")]
        public List<int> RegionIds { get; set; }
        public SelectList ListofRegions { get; set; }

        [Required]
        [Display(Name = "Общее количество участников *")]
        public int TotalNumberParticipants { get; set; }

        [Required]
        [Display(Name = "Количество участников из числа обучающихся *")]
        public int NumberParticipantsOfStudents { get; set; }

        [Required]
        [Display(Name = "Объем запрашиваемой субсидии *")]
        public decimal AmountRequestedSubsidy { get; set; }

        [Required]
        [Display(Name = "Объем собственных и привлеченных денежных средств *")]
        public decimal VolumeOwnAttractedFunds { get; set; }

        [Required]
        [Display(Name = "Количество мероприятий в плане реализации *")]
        public int NumberActivitiesImplementation { get; set; }

        [Required]
        [Display(Name = "Порядок управления Мероприятием (краткое описание) *")]
        public string ManagingActionDescription { get; set; }

        [Required]
        [Display(Name  = "Дата начала")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name ="Дата окончания")]
        public DateTime StopDateTime { get; set; }

        [Required]
        [Display(Name = "План реализации мероприятия *")]
        public string ManagingAction { get; set; }

    }

    public enum EventType
    {
        /// <summary>
        /// Международные мероприятия
        /// </summary>
        InternationalEvents,
        /// <summary>
        /// Всероссийские мероприятия
        /// </summary>
        AllRussianEvents,
        /// <summary>
        /// Межрегиональный уровень
        /// </summary>
        InterregionalLevel,
        /// <summary>
        /// Региональный уровень
        /// </summary>
        RegionalLevel,
        /// <summary>
        /// Внутризовский уровень
        /// </summary>
        IntraUniversityLevel
    }
}

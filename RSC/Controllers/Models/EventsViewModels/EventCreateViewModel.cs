using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.EventsViewModels
{
    public class EventCreateViewModel
    {
        #region property 

        public int Id { get; set; }
        public int PrdsoId { get; set; }

        [Required]
        [Display(Name = "Наименование мероприятия")]
        public string NameEvent { get; set; }

        [Required]
        [Display(Name = "Цель мероприятия и его краткое содержание")]
        public string PurposeOfTheEvent { get; set; }

        [Required]
        [Display(Name = "Ожидаемые эффекты от реализации мероприятия")]
        public string ExpectedEffectsOfTheEvent { get; set; }

        [Required]
        [Display(Name = "Период реализации мероприятия, с")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name = "До")]
        public DateTime StopDateTime { get; set; }

        [Required]
        [Display(Name = "Количество ООВО")]
        public int CountOOVO { get; set; }

        [Required]
        [Display(Name = "Общее количество участников, чел")]
        public int TotalNumberOfParticipants { get; set; }

        [Required]
        [Display(Name = "Колияество участников из числа обучающихся в данной ООВО, чел")]
        public int NumberOfParticipantsInThisOOVO { get; set; }

        [Required]
        [Display(Name = "Количество учатников за счет средств субсидииб чел")]
        public int NumberOfParticipantsWithSubsidies { get; set; }

        [Required]
        [Display(Name = "Количество участников без учета средств субсидииб чел")]
        public int NumberOfParticipantsWithoutSubsidy { get; set; }

        [Required]
        [Display(Name = "План реализации мероприятия")]
        public string ImplementationPlan { get; set; }

        [Required]
        [Display(Name = "Количество мероприятий в плане реализации")]
        public int CountImplementaionEvents { get; set; }

        [Required]
        [Display(Name = "И их краткое содержание")]
        public string ImplementationEventsShotInfo { get; set; }

        [Required]
        [Display(Name = "Порядок управления Мероприятием(краткое описание)")]
        public string OrderOfEventManagement { get; set; }

        [Required]
        [Display(Name = "Меры по обеспечению публичности хода и результатов реализации Мероприятия(краткое описание)")]
        public string MeasuresToEnsurePublicityEvent { get; set; }

        #endregion

        #region property type SelectList 

        [Required]
        [Display(Name = "Тип мероприятия")]
        public int EventTypeId { get; set; }
        public SelectList EventTypes { get; set; }

        [Required]
        [Display(Name = "Направление мероприятия")]
        public int EventDirectionId { get; set; }
        public SelectList EventDirections { get; set; }

        [Required]
        [Display(Name = "Регионы")]
        public int RegionId { get; set; }
        public SelectList Regions { get; set; }

        #endregion

        #region property type list

        public List<Data.DbModels.TargetIndicator> TargetIndicators { get; set; }
        public List<Cost> Costs { get; set; }
        public List<CostSection> CostSections { get; set; }

        #endregion

        #region default constuctor

        public EventCreateViewModel()
        {
            TargetIndicators = new List<Data.DbModels.TargetIndicator>();
            Costs = new List<Cost>();
            CostSections = new List<CostSection>();
        }

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class Event
    {
        public int Id { get; set; }

        public int PrdsoId { get; set; }
        public virtual Prdso Prdso { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name = "До")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StopDateTime { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Required]
        [Display(Name="Место проведения мероприятия")]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "Контакты")]
        public string Contacts { get; set; }
        
        [Required]
        [Display(Name = "Стоимость участия")]
        public string TicketPrice { get; set; }

        [Required]
        [Display(Name = "Количество ООВО")]
        public int CountOOVO { get; set; }

        [Required]
        [Display(Name = "Общее количество участников, чел")]
        public int TotalNumberOfParticipants { get; set; }

        [Required]
        [Display(Name = "Количество участников из числа обучающихся в данной ООВО, чел")]
        public int NumberOfParticipantsInThisOOVO { get; set; }

        [Required]
        [Display(Name = "Количество участников за счет средств субсидии чел")]
        public int NumberOfParticipantsWithSubsidies { get; set; }

        [Required]
        [Display(Name = "Количество участников без учета средств субсидии чел")]
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

        [Required]
        [Display(Name = "Направление мероприятия")]
        public int EventDirectionId { get; set; }
        public virtual EventDirection EventDirection { get; set; }

        [Required]
        [Display(Name = "Объем запрашиваемой субсидии")]
        public decimal AmountOfTheRequestedSubsidy { get; set; }

        [Required]
        [Display(Name = "Объем собственных денежных средств")]
        public decimal AmountOfOwnSubsidy { get; set; }

        [Required]
        [Display(Name = "Объем  привлеченных денежных средств")]
        public decimal AmountOfAttractedSubsidy { get; set; }

        [Required]
        [Display(Name = "Регионы")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        [Display(Name = "Статус")]
        public int? EventStatusId { get; set; }
        public EventStatus EventStatus { get; set; }

        [Display(Name = "Состояние")]
        public int? EventStateId { get; set; }
        public EventState EventState { get; set; }

        public virtual List<TargetIndicator> TargetIndicators { get; set; }
        public virtual List<Cost> Costs { get; set; }
        public virtual PublicEventInformation PublicEventInformation { get; set; }
    }
}

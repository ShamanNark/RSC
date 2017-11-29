using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSC.Models.NewsRubricsViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class CreateNewsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Оглавление")]
        public string Title { get; set; }
        [DisplayName("Содержание")]
        public string Text { get; set; }
        [DisplayName("Изображение")]
        public IFormFile MainImage { get; set; }
        public string HomePageImage { get; set; }
        [DisplayName ("Рубрики")]
        public List<int> SelectedRubrics { get; set; }
        [DisplayName("Список рубрик")]
        public SelectList NewsRubrics {get;set;}
    }
}

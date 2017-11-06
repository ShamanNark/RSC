using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Оглавление")]
        public string Title { get; set; }
        [DisplayName("Содержание")]
        public string Text { get; set; }
        [DisplayName("Изображение")]
        public string MainImagePath { get; set; }
        [DisplayName("Изображение для главной страницы")]
        public string HomePageImagePath { get; set; }
        [DisplayName("Изображение")]
        public IFormFile MainImage { get; set; }
        [DisplayName("Изображение для главной страницы")]
        public IFormFile HomePageImage { get; set; }
        [DisplayName("Рубрика")]
        public List<int> SelectedRubrics { get; set; }
        [DisplayName("Список рубрик")]
        public SelectList NewsRubrics { get; set; }
        [DisplayName("Дата создания")]
        public DateTime CreateDateTime { get; set; }
    }
}

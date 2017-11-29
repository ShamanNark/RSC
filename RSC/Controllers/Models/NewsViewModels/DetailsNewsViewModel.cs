using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class DetailsNewsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Оглавление")]
        public string Title { get; set; }
        [DisplayName("Содержание")]
        public string Text { get; set; }
        [DisplayName("Изображение")]
        public string MainImagePath { get; set; }
        public string HomePageImagePath { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}

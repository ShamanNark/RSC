﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string MainImagePath { get; set; }
        public string AdditionalImagePath { get; set; }
        public IFormFile MainImage { get; set; }
        public IFormFile AdditionalImage { get; set; }
        public List<int> SelectedRubrics { get; set; }
        public SelectList NewsRubrics { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}

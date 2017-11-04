using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class ObjectNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string MainImage { get; set; }
        public string AdditionalImages { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public List<ObjectNewsNewsRubric> ListObjectNewsNewsRubric { get; set; }

        public ObjectNews()
        {
            ListObjectNewsNewsRubric = new List<ObjectNewsNewsRubric>();
        }
    }
}

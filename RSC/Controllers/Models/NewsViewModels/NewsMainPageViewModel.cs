using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models.NewsViewModels
{
    public class NewsMainPageViewModel
    {
        public List<ObjectNewsNewsRubric> Blogs { get; set; }
        public List<ObjectNewsNewsRubric> Interviews { get; set; }
        public List<ObjectNewsNewsRubric> News { get; set; }
        public List<Event> Announs { get; set; }

        public NewsMainPageViewModel()
        {
            Blogs = new List<ObjectNewsNewsRubric>();
            Interviews = new List<ObjectNewsNewsRubric>();
            News = new List<ObjectNewsNewsRubric>();
            Announs = new List<Event>();
        }

    }
}

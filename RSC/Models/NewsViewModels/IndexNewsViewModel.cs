using PagedList;
using RSC.Models.NewsRubricsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class IndexNewsViewModel
    {
        public List<DetailsNewsViewModel> News { get; set; }
        public List<NewsRubricViewModel> NewsRubrics { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public IndexNewsViewModel()
        {
            NewsRubrics = new List<NewsRubricViewModel>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RSC.Models.NewsViewModels;

namespace RSC.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public List<DetailsNewsViewModel> News { get; set; }

        public HomeIndexViewModel()
        {
            News = new List<DetailsNewsViewModel>();
        }
    }
}

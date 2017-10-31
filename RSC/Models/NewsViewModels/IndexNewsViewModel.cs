using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.NewsViewModels
{
    public class IndexNewsViewModel
    {
        public List<DetailsNewsViewModel> News { get; set; }

        public IndexNewsViewModel()
        {
            News = new List<DetailsNewsViewModel>();
        }
    }
}

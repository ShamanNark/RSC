using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class StudStarterEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public int EventMainFotoId { get; set; }
        public FileModel EventMainFoto { get; set; }
        public int EventSmallFotoId { get; set; }
        public FileModel EventSmallFoto { get; set; }
    }
}

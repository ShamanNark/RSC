using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Data.DbModels
{
    public class CoPersonalFile
    {
        public int Id { get; set; }
        public int StudentCouncilId { get; set; }
        public virtual StudentsCouncil StudentsCouncil { get; set; }
        public int FileId { get; set; }
        public virtual FileModel File { get; set; }
    }
}

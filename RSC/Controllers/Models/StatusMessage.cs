using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Controllers.Models
{
    public class StatusMessage
    {
        public TypeStatusMessage Type { get; set; }
        public string Message { get; set; }
    }

    public enum TypeStatusMessage
    {
        Success,
        Error
    }
}

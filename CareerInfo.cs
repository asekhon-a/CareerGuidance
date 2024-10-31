using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Career
    {
        public int CareerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequiredStudies { get; set; }
        public bool InDemand { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
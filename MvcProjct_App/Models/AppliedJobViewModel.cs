using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class AppliedJobViewModel
    {
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set; }
        public string Resume { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
    }
}
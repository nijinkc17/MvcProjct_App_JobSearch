using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class ApplyJobcls
    {
        public int User_id { get; set; }
        public int Job_id { get; set; }
        public string Resume { get; set; }
        public System.DateTime Application_date { get; set; }
        public string Status { get; set; }

        public string msg { get; set; }
    }
}
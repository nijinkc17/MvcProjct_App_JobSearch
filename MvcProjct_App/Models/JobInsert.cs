using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class JobInsert
    {
        //public int Jb_id { get; set; }
        //public int Cmp_id { get; set; }
        [Required(ErrorMessage = "Enter jobtitle")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter valid experince")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Enter skills")]
        public string Skill { get; set; }
        public int No_vaccancy { get; set; }
        public System.DateTime Date { get; set; }
        public int Status { get; set; }
        
        public string msg { get; set; }
    }
}
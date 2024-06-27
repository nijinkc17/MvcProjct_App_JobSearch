using System;
using System.ComponentModel.DataAnnotations;

namespace MvcProjct_App.Models
{
    public class JobUpdate
    {
        public int jb_id { get; set; }

        [Required(ErrorMessage = "Enter job title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter valid experience")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Enter skills")]
        public string Skill { get; set; }

        public int No_vaccancy { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

        public string msg { get; set; }
    }
}

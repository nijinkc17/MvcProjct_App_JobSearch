using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class UserInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string u_name { get; set; }

        [Range(18, 50, ErrorMessage = " Age must between 18-50")]
        public int u_age { get; set; }

        [Required(ErrorMessage = "Enter the Address")]
        public string u_address { get; set; }

        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string u_phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid mail id")]
        public string u_email { get; set; }

        [Required(ErrorMessage = "Enter the Qualification")]
        public string qualification { get; set; }
        public string experience { get; set; }

        [Required(ErrorMessage = "Enter your skills")]
        public string skills { get; set; }
        public string photo { get; set; }
        public string resume { get; set; }

        public string username { get; set; }
        public string pass { get; set; }

        [Compare("pass", ErrorMessage = "password missmatch!")]
        public string cpassword { get; set; }
        public string usermsg { get; set; }

    }
}
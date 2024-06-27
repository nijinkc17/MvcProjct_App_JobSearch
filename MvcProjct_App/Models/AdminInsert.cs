using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class AdminInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string c_name { get; set; }

        [Required(ErrorMessage = "Enter the address")]
        public string c_address { get; set; }

        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string c_phone { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid mail id")]
        public string c_email { get; set; }

        [Required(ErrorMessage = "Enter location")]
        public string c_location { get; set; }

        public string username { get; set; }

        public string pass { get; set; }

        [Compare("pass", ErrorMessage = "password missmatch")]
        public string cpassword { get; set; }
        public string adminmsg { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcProjct_App.Models;

namespace MvcProjct_App.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter the username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }

        public string msg { get; set; }
        public string LogType { get; set; }
    }
}
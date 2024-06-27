using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class AdminRegController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
        // GET: AdminReg
        public ActionResult Insertadmin_pageload()
        {
            return View();
        }
        public ActionResult Insertadmin_click(AdminInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_adminReg(regid, clsobj.c_name, clsobj.c_address, clsobj.c_phone, clsobj.c_email,clsobj.c_location);
                dbobj.sp_logInsert(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.adminmsg = "successfully inserted";
                return View("Insertadmin_pageload", clsobj);
            }

            return View("Insertadmin_pageload", clsobj);
        }
    }
}
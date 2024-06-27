using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class UserRegController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();

        // GET: UserReg
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult Insert_click(UserInsert clsobj, HttpPostedFileBase file, HttpPostedFileBase file2)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.photo = fullpath;//set
                }
                if (file2.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file2.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Resume", fname);
                    clsobj.resume = fullpath;//set
                }
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
                dbobj.sp_userReg(regid, clsobj.u_name, clsobj.u_age, clsobj.u_address,clsobj.u_phone, clsobj.u_email,clsobj.qualification, clsobj.experience, clsobj.skills, clsobj.photo, clsobj.resume);
                dbobj.sp_logInsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "successfully inserted";
                return View("Insert_Pageload", clsobj);
            }

            return View("Insert_Pageload", clsobj);
        }
    }
}
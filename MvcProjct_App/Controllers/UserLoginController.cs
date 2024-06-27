using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class UserLoginController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
        // GET: UserLogin
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            var data = dbobj.sp_SelectAlljobs().ToList();
            ViewBag.jobtab = data;
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Login_Click(LoginCls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.Username, objcls.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.Username, objcls.Password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_loginType(objcls.Username, objcls.Password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "admin")
                    {
                        return RedirectToAction("AdminHome");

                    }
                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid login";
                return View("Login_pageload", objcls);
            }

            return View("Login_pageload", objcls);
        }
    }
}
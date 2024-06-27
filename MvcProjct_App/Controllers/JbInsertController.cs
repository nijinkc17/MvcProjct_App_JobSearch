using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class JbInsertController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
        // GET: JbInsert
        public ActionResult jobPageload()
        {
            return View();
        }
        public ActionResult job_click(JobInsert objcls)
        {
            var Dt = DateTime.Now;
            int st = 1;
            
            int rid =Convert.ToInt32(Session["uid"]);
            if (ModelState.IsValid)
            {
                dbobj.sp_jobInsert(rid, objcls.Title, objcls.Experience, objcls.Skill, objcls.No_vaccancy,Dt,st);
                objcls.msg = "successfully inserted";
                return View("jobPageload", objcls);

            }
            return View("jobPageload", objcls);

            
        }

    }
}
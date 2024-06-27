using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class ApplyJobController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
       

        // GET: ApplyJob
        public ActionResult ApplyJob_pageload(int id)
        {
            //Session["id"] = id;
            return View();
        }
        public ActionResult ApplyJob_click(ApplyJobcls objcls, HttpPostedFileBase file)
        {

            int getid =Convert.ToInt32(Session["id"]);
            int rid = Convert.ToInt32(Session["uid"]);
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Resume", fname);
                    objcls.Resume = fullpath;//set
                }

                dbobj.sp_InsertJobApplication(rid, getid, objcls.Resume, objcls.Application_date, "applied");
                objcls.msg = "successfully Applied";
                return View("ApplyJob_pageload", objcls);

            }
            return View("ApplyJob_pageload", objcls);

            
        }
    }
}
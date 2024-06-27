using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class SelectAlljobController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();

        // GET: SelectAlljob
        public ActionResult DisplayAlljob_pageload()
        {
            var data = dbobj.sp_SelectAlljobs().ToList();
            ViewBag.jobtab = data;
            return View();
        }

        public ActionResult DisplayAll_Applied_job_pageload()
        {
            var data = dbobj.ApplyJob_tab
                .Include("Job_tab")
                .Include("UserReg")
                .Select(a => new AppliedJobViewModel
                {
                    Title = a.Job_tab.Title,
                    Experience = a.Job_tab.Experience,
                    Skill = a.Job_tab.Skill,
                    Resume = a.Resume,
                    ApplicationDate = a.Application_date,
                    Status = a.Status,
                    UserName = a.UserReg.u_name
                })
                .ToList();

            return View(data);
        }
    }
}

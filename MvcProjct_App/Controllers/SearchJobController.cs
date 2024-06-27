using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class SearchJobController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();

        // GET: SearchJob
        public ActionResult Searchjob_pageload()
        {
            return View(GetData());
        }

        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.Job_tab.ToList();
            foreach (var item in job)
            {
                var jobcls = new Jsearch();
                jobcls.Jb_id = item.Jb_id;
                jobcls.Cmp_id = item.Cmp_id;
                jobcls.Title = item.Title;
                jobcls.Experience = item.Experience;
                jobcls.Skill = item.Skill;
                jobcls.No_vaccancy = item.No_vaccancy;
                jobcls.Date = item.Date;
                jobcls.Status = item.Status;
                joblist.selectjob.Add(jobcls);
                lst.Add(jobcls.Skill);
                lst.Add(jobcls.Experience);
            }
            TempData["ski"] = string.Join(" ", lst);
            return joblist;
        }

        public ActionResult Searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertSe.Title))
            {
                qry += " and Title like '%" + clsobj.insertSe.Title + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertSe.Skill))
            {
                qry += " and Skill like '%" + clsobj.insertSe.Skill + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertSe.Experience))
            {
                qry += " and Experience like '%" + clsobj.insertSe.Experience + "%'";
            }
            return View("Searchjob_pageload", getdata1(qry));
        }

        private JobSearch getdata1(string qry)
        {
            var joblist = new JobSearch();
            var data = dbobj.Database.SqlQuery<Jsearch>("EXEC sp_jobSearch @qry", new SqlParameter("@qry", qry)).ToList();

            foreach (var item in data)
            {
                var jobcls = new Jsearch();
                jobcls.Jb_id = item.Jb_id;
                jobcls.Cmp_id = item.Cmp_id;
                jobcls.Title = item.Title;
                jobcls.Experience = item.Experience;
                jobcls.Skill = item.Skill;
                jobcls.No_vaccancy = item.No_vaccancy;
                jobcls.Date = item.Date;
                jobcls.Status = item.Status;
                joblist.selectjob.Add(jobcls);
            }
            return joblist;
        }
    }
}

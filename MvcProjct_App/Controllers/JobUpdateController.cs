using System;
using System.Linq;
using System.Web.Mvc;
using MvcProjct_App.Models;

namespace MvcProjct_App.Controllers
{
    public class JbUpdateController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();

        // GET: JbUpdate/Edit/5
        public ActionResult Edit_pageload(int id)
        {
            var getdata = dbobj.Job_tab.Find(id);
            if (getdata == null)
            {
                return HttpNotFound();
            }

            var jobUpdate = new JobUpdate
            {
                jb_id = getdata.Jb_id,
                Title = getdata.Title,
                Experience = getdata.Experience,
                Skill = getdata.Skill,
                No_vaccancy = getdata.No_vaccancy,
                Date = getdata.Date,
                Status = getdata.Status
            };

            return View(jobUpdate);
        }

        // POST: JbUpdate/Edit/5
        [HttpPost]
        public ActionResult Edit(JobUpdate obj)
        {
            if (ModelState.IsValid)
            {
                dbobj.sp_UpdateJob(obj.jb_id, obj.Title, obj.Experience, obj.Skill, obj.No_vaccancy, obj.Date, obj.Status);
                obj.msg = "Successfully updated";
                //return RedirectToAction("Edit_pageload", new { id = obj.jb_id });
                return RedirectToAction("DisplayAlljob_pageload","SelectAlljob");
            }

            return View(obj);
        }
        public ActionResult delete_pageload(int id)
        {
            var getdata = dbobj.Job_tab.Find(id);
            if (getdata == null)
            {
                return HttpNotFound();
            }

            var jobUpdate = new JobUpdate
            {
                jb_id = getdata.Jb_id,
                Title = getdata.Title,
                Experience = getdata.Experience,
                Skill = getdata.Skill,
                No_vaccancy = getdata.No_vaccancy,
                Date = getdata.Date,
                Status = getdata.Status
            };

            return View(jobUpdate);
        }
        // POST: JbUpdate/Delete/5
        [HttpPost]
        public ActionResult Delete(JobUpdate obj)
        {
            //var getdata = dbobj.Job_tab.Find(id);
            //if (getdata == null)
            //{
            //    return HttpNotFound();
            //}

            dbobj.sp_deleteJob(obj.jb_id);
            return RedirectToAction("DisplayAlljob_pageload", "SelectAlljob");
        }
    }
}

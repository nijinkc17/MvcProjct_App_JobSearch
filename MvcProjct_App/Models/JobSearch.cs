using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjct_App.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<Jsearch>();

            insertSe = new Jsearch();
        }

        public Jsearch insertSe { set; get; }
        public List<Jsearch> selectjob { set; get; }

       
    }
    public class Jsearch
    {
        public int Jb_id { get; set; }
        public int Cmp_id { get; set; }
        public string Title { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set; }
        public int No_vaccancy { get; set; }
        public System.DateTime Date { get; set; }
        public int Status { get; set; }
        public string msg { get; set; }
    }
}
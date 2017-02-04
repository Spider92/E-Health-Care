using E_Health.Models;
using E_Health.Models.DataContext;
using E_Health.Models.Information;
using E_Health.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        DoctorContext dc = new DoctorContext();
        public ActionResult Chat()
        {
            Session["Name"] = "Shibli";
            return View();
        }
        public ActionResult PostProblem()
        {
            if (Session["PatientId"] != null)
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "Yes";
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult PostProblem(Problem p)
        {
            int UserId = (int)Session["UserId"];


            if (ModelState.IsValid)
            {
                var x = dc.Registers.Where(c => c.UserId == UserId).FirstOrDefault();
                if (x != null)
                {
                    p.UserId = UserId;
                    p.Name = x.Name;
                    p.Email = x.Email;

                    dc.Problems.Add(p);
                    dc.SaveChanges();
                    TempData["posted"] = "Yes";
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(p);



        }
        public ActionResult SendReports()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendReports(Report report)
        {
            int userid = (int)Session["UserId"];
            if (ModelState.IsValid)
            {
                report.UserId = userid;
                report.Department = (string)Session["User_Dept"];
                dc.Reports.Add(report);
                dc.SaveChanges();
                TempData["Report"] = "Report sent successfully!";
                return RedirectToAction("View_Report_User", "Patient");

            }
            else
            {
                return Content("You have not filled the report field!");
            }
            

        }
        public ActionResult View_Report_User()
        {
            int userid = (int)Session["UserId"];
            string dept = (string)Session["User_Dept"];
            var user = dc.RoomUsers.Where(m => m.Busy == "true" && m.UserId.Equals(userid) && m.Department.Equals(dept)).FirstOrDefault();
            return View(dc.Reports.Where(m => m.UserId.Equals(userid) && m.Department.Equals(dept)).ToList());

        }
        public ActionResult Delete_Report(int id)
        {
            Report report = dc.Reports.Find(id);
            dc.Reports.Remove(report);
            dc.SaveChanges();
            return RedirectToAction("View_Report_User");
        }



        public ActionResult View_Medicine()
        {
            return View(dc.Medicines.Where(m => m.MedicineId ==2));
        }
        public ActionResult View_Blocked_Medicine(int id)
        {
            return View(dc.Medicines.Where(m=>m.MedicineId==id));
        }



        public ActionResult View_News()
        {
            return View(dc.LatestNewss.Where(m=>m.NewsId==1));
        }
        public ActionResult View_Latest_News(int id)
        {
            return View(dc.LatestNewss.Where(m => m.NewsId == id));
        }


        public ActionResult Blocked_medicine_partial()
        {
            return PartialView(dc.Medicines.ToList());
        }
        public ActionResult Latest_news_partial()
        {
            return PartialView(dc.LatestNewss.ToList());
        }
    }
}

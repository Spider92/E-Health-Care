using E_Health.Models;
using E_Health.Models.DataContext;
using E_Health.Models.FA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class FirstAidController : Controller
    {


        DoctorContext dc = new DoctorContext();


        public ActionResult ViewFirstAids()
        {
            return View(dc.FirstAids.ToList());
        }


        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(FirstAid fa)
        {
            if (ModelState.IsValid)
            {
                dc.FirstAids.Add(fa);
                dc.SaveChanges();
                return RedirectToAction("ViewFirstAids");
            }
            return View();
        }

        public ActionResult Edit_FirstAid(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FirstAid fa = dc.FirstAids.Find(id);
            if (fa == null)
            {
                return HttpNotFound();
            }
            return View(fa);
        }
        [HttpPost]
        public ActionResult Edit_FirstAid(FirstAid fa)
        {
            if (ModelState.IsValid)
            {
                dc.Entry(fa).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("ViewFirstAids");
            }
            return View(fa);
        }
        public ActionResult GetFirstAid()
        {
            return View(dc.FirstAids.Where(m => m.Title.Contains("Symbol")).ToList());
        }

        [HttpPost]
        public ActionResult GetFirstAid(string search_fa)
        {
            var treatment = from m in dc.FirstAids select m;
            if (String.IsNullOrEmpty(search_fa))
            {

                return RedirectToAction("GetFirstAid");

            }
            treatment = treatment.Where(s => s.Title.Contains(search_fa));
            return View(treatment);

        }
        public ActionResult Delete_Fa(int id)
        {
            var find = dc.FirstAids.Find(id);
            dc.FirstAids.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("ViewFirstAids");
        }
        public ActionResult Search_FA()
        {
            return View();
        }

        public ActionResult SideView()
        {
            return PartialView();
        }
    }
}
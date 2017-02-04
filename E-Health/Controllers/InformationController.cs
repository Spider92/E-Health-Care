using E_Health.Models.DataContext;
using E_Health.Models.Information;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Models
{
    public class InformationController : Controller
    {
        //
        // GET: /Information/
        DoctorContext dc = new DoctorContext();
        public ActionResult Index()
        {
            var news = dc.LatestNewss.ToList();
            return View(news);
        }

        public ActionResult View_Banner()
        {
            var banner = dc.Banners.ToList();
            return View(banner);
        }
        public ActionResult View_News()
        {
            var news = dc.LatestNewss.ToList();
            return View(news);
        }
        public ActionResult View_Tips()
        {
            var tips = dc.Tips.ToList();
            return View(tips);
        }
        public ActionResult View_Medicine()
        {
            var medicine = dc.Medicines.ToList();
            return View(medicine);
        }
        public ActionResult Add_News()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_News(LatestNews news)
        {
            if (ModelState.IsValid)
            {
                dc.LatestNewss.Add(news);
                dc.SaveChanges();
                return RedirectToAction("view_news");
            }
            return View();
        }
        public ActionResult Edit_News(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LatestNews news = dc.LatestNewss.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        [HttpPost]
        public ActionResult Edit_News(LatestNews news)
        {
            if (ModelState.IsValid)
            {
                dc.Entry(news).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("view_news");
            }
            return View(news);
        }
        public ActionResult Delete_News(int id)
        {
            var find = dc.LatestNewss.Find(id);
            dc.LatestNewss.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("view_news");
        }

        public ActionResult Add_Tips()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Tips(Health_Tips tips)
        {
            if (ModelState.IsValid)
            {
                dc.Tips.Add(tips);
                dc.SaveChanges();
                return RedirectToAction("view_tips");
            }
            return View();
        }
        public ActionResult Edit_Tips(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Health_Tips tips = dc.Tips.Find(id);
            if (tips == null)
            {
                return HttpNotFound();
            }
            return View(tips);
        }

        [HttpPost]
        public ActionResult Edit_Tips(Health_Tips tips)
        {
            if (ModelState.IsValid)
            {
                dc.Entry(tips).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("view_tips");
            }
            return View(tips);
        }
        public ActionResult Delete_Tips(int id)
        {
            var find = dc.Tips.Find(id);
            dc.Tips.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("view_tips");
        }
        public ActionResult Add_Blocked_Medicine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Blocked_Medicine(Blocked_Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                dc.Medicines.Add(medicine);
                dc.SaveChanges();
                return RedirectToAction("View_Medicine");
            }
            return View();
        }
        public ActionResult Edit_Blocked_Medicine(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Blocked_Medicine medicine = dc.Medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        [HttpPost]
        public ActionResult Edit_Blocked_Medicine(Blocked_Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                dc.Entry(medicine).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("View_Medicine");
            }
            return View(medicine);
        }
        public ActionResult Delete_Blocked_Medicine(int id)
        {
            var find = dc.Medicines.Find(id);
            dc.Medicines.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("View_Medicine");
        }

        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Health_Banner banner, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string dirUrl = "~/Health_Banner/";
                    string dir = Server.MapPath(dirUrl);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    var extension = Path.GetExtension(file.FileName);
                    file.SaveAs(HttpContext.Server.MapPath(dirUrl) + file.FileName);
                    banner.Image = file.FileName;
                }
                dc.Banners.Add(banner);
                dc.SaveChanges();
                return RedirectToAction("View_Banner");
            }
            return View();
        }

        public ActionResult Delete_Banner(int? id)
        {
            var find = dc.Banners.Find(id);
            dc.Banners.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("View_Banner");
        }
        public ActionResult SideView()
        {
            return PartialView();
        }

    }
}
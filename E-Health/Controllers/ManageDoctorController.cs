using E_Health.Models.DataContext;
using E_Health.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class ManageDoctorController : Controller
    {
        DoctorContext dc = new DoctorContext();

        //
        // GET: /ManageDoctor/
        public ActionResult ViewDoctor()
        {
            if (Session["AdminId"] != null)
            {
                return View(dc.Docs.ToList());
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }

        public ActionResult AddDoctor()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult AddDoctor(Doctors doctor, HttpPostedFileBase file, string Password, string ConfirmPassword)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string dirUrl = "~/Doctor_Photos/";
                    string dir = Server.MapPath(dirUrl);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    var extension = Path.GetExtension(file.FileName);
                    file.SaveAs(HttpContext.Server.MapPath(dirUrl) + file.FileName);
                    doctor.Photo = file.FileName;
                }
                doctor.Password = hashedPassword;
                doctor.ConfirmPassword = hashed_c_password;
                dc.Docs.Add(doctor);
                dc.SaveChanges();
                return RedirectToAction("ViewDoctor");
            }
            return View();
        }
        public ActionResult EditDoctor(int? id)
        {
            if (Session["AdminId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Doctors doctor = dc.Docs.Find(id);
                if (doctor == null)
                {
                    return HttpNotFound();
                }
                return View(doctor);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult EditDoctor(Doctors doctor, string Password, string ConfirmPassword, HttpPostedFileBase file)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    file.SaveAs(HttpContext.Server.MapPath("~/Doctor_Photos/") + file.FileName);
                    doctor.Photo = file.FileName;
                }
                doctor.Password = hashedPassword;
                doctor.ConfirmPassword = hashed_c_password;
                dc.Entry(doctor).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("ViewDoctor");
            }
            return View(doctor);
        }

        public ActionResult DeleteDoctor(int id)
        {
            if (Session["AdminId"] != null)
            {
                Doctors doctor = dc.Docs.Find(id);
                dc.Docs.Remove(doctor);
                dc.SaveChanges();
                return RedirectToAction("ViewDoctor");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Male_Doctor()
        {
            if (Session["AdminId"] != null)
            {
                return View(dc.Docs.Where(m => m.Gender.Equals("Male")).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Female_Doctor()
        {
            if (Session["AdminId"] != null)
            {
                return View(dc.Docs.Where(m => m.Gender.Equals("Female")).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult AdminSideView_Doctor()
        {
            return PartialView();
        }

    }
}
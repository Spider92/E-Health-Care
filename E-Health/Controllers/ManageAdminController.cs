using E_Health.Models.Admin;
using E_Health.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class ManageAdminController : Controller
    {

        DoctorContext dc = new DoctorContext();
        //
        // GET: /ManageAdmin/
        public ActionResult ViewAdmin()
        {
            if (Session["AdminId"] != null)
            {
                var admin = dc.Admins.ToList();
                return View(admin);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        public ActionResult AddAdmin()
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
        public ActionResult AddAdmin(AdminModel model, string Password, string ConfirmPassword)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if (ModelState.IsValid)
            {
                model.Password=hashedPassword;
                model.ConfirmPassword=hashed_c_password;
                dc.Admins.Add(model);
                dc.SaveChanges();
                return RedirectToAction("ViewAdmin", "ManageAdmin");
            }
            return View();
        }

        public ActionResult EditAdmin(int? id)
        {
            if (Session["AdminId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                AdminModel admin = dc.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult EditAdmin(AdminModel admin, string Password, string ConfirmPassword)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if(ModelState.IsValid)
            {
                admin.Password = hashedPassword;
                admin.ConfirmPassword = hashed_c_password;
                dc.Entry(admin).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("ViewAdmin","ManageAdmin");
            }
            return View(admin);
        }

        public ActionResult DeleteAdmin(int id)
        {
            if (Session["AdminId"] != null)
            {
                AdminModel admin = dc.Admins.Find(id);
                dc.Admins.Remove(admin);
                dc.SaveChanges();
                return RedirectToAction("ViewAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult SideView()
        {
            return PartialView();
        }
    }
}
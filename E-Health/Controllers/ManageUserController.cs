using E_Health.Models.Account;
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
    public class ManageUserController : Controller
    {

        DoctorContext dc = new DoctorContext();
        //
        // GET: /ManageUser/
        public ActionResult ViewUser()
        {
            if (Session["AdminId"] != null)
            {
                var users = dc.Registers.ToList();
                return View(users);
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        public ActionResult Male_User()
        {
            if (Session["AdminId"] != null)
            {
                return View(dc.Registers.Where(m => m.Gender.Equals("Male")).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Female_User()
        {
            if (Session["AdminId"] != null)
            {
                return View(dc.Registers.Where(m => m.Gender.Equals("Female")).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult EditUser(int? id)
        {
            if (Session["AdminId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Register user = dc.Registers.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult EditUser(Register user, string Password, string ConfirmPassword)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if (ModelState.IsValid)
            {
                user.Password = hashedPassword;
                user.ConfirmPassword = hashed_c_password;
                dc.Entry(user).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("viewuser");
            }
           
            return View(user);
        }

        public ActionResult DeleteUser(int id)
        {
            if (Session["AdminId"] != null)
            {
                Register user = dc.Registers.Find(id);
                dc.Registers.Remove(user);
                dc.SaveChanges();
                return RedirectToAction("ViewUser");
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
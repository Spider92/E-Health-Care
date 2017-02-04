using E_Health.Models.Account;
using E_Health.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Health.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        DoctorContext dc = new DoctorContext();

        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(Register register, string Email, string Password, string ConfirmPassword)
        {
            string hashedPassword = Crypto.SHA1(Password);
            string hashed_c_password = Crypto.SHA1(ConfirmPassword);
            if (ModelState.IsValid)
            {
               
                var check_user = dc.Registers.Where(m => m.Email.Equals(Email)).FirstOrDefault();
                var check_doctors = dc.Docs.Where(m => m.Email.Equals(Email)).FirstOrDefault();
                var check_admin = dc.Admins.Where(m => m.AdminEmail.Equals(Email)).FirstOrDefault();
                if (check_user == null && check_doctors == null && check_admin == null)
                {
                    register.Password = hashedPassword;
                    register.ConfirmPassword=hashed_c_password;
                    dc.Registers.Add(register);
                    dc.SaveChanges();
                    TempData["registration"] = "True";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["registered"] = "True";
                    return View();
                }

            }
            return View(register);

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string Password)
        {
            string hashedPassword = Crypto.SHA1(Password);
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Email, true);

                var checkuser = dc.Registers.Where(m => m.Email.Equals(model.Email)
                            && m.Password.Equals(hashedPassword)).FirstOrDefault();

                var checkdoctor = dc.Docs.Where(m => m.Email.Equals(model.Email)
                           && m.Password.Equals(hashedPassword)).FirstOrDefault();

                var checkadmin = dc.Admins.Where(m => m.AdminEmail.Equals(model.Email)
                          && m.Password.Equals(hashedPassword)).FirstOrDefault();

                if (checkuser != null)
                {
                    Session["UserName"] = checkuser.Name;
                    Session["PatientId"] = checkuser.UserId;
                    Session["UserId"] = checkuser.UserId;
                    return RedirectToAction("Index", "Home");
                }

                else if (checkdoctor != null)
                {
                    Session["UserId"] = checkdoctor.DoctorId;
                    Session["DoctorId"] = checkdoctor.DoctorId;
                    Session["DoctorName"] = checkdoctor.DoctorName;
                    Session["Department"] = checkdoctor.Division;
                    return RedirectToAction("Index", "Doctor");
                }
                else if (checkadmin != null)
                {
                    Session["UserId"] = checkadmin.AdminId;
                    Session["AdminId"] = checkadmin.AdminId;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["login"] = "False";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-2);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
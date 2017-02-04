using E_Health.Models.DataContext;
using E_Health.Models.Doctor;
using E_Health.Models.Information;
using E_Health.Models.Patient;
using E_Health.Models.UserInRoom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class DoctorController : Controller
    {

        DoctorContext dc = new DoctorContext();
        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            if (Session["DoctorId"] != null)
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }


        public ActionResult Skin_Chat()
        {
            if (Session["DoctorId"] != null && (string)Session["Department"]=="Skin")
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult Medicine_Chat()
        {

            if (Session["DoctorId"] != null && (string)Session["Department"] == "Medicine")
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult Neurology_Chat()
        {

            if (Session["DoctorId"] != null && (string)Session["Department"] == "Neurology")
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Cardiology_Chat()
        {

            if (Session["DoctorId"] != null && (string)Session["Department"] == "Cardiology")
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Gynaecology_Chat()
        {

            if (Session["DoctorId"] != null && (string)Session["Department"] == "Gynaecology")
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Prescription(HttpPostedFileBase fileUploader, RoomUser user)
        {

            string email = user.Email;
            string from = "onlineservice92@gmail.com";
            string department = (string)Session["Department"];
            var check = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department.Equals(department)).FirstOrDefault();
            string To = check.Email;

            using (MailMessage mail = new MailMessage(from, To))
            {

                mail.Subject = "Prescription";

                mail.Body = "Thanks for your consultation.Please follow the prescription";

                if (fileUploader != null)
                {

                    string fileName = Path.GetFileName(fileUploader.FileName);

                    mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

                }

                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential(from, "apadat1992");

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = networkCredential;

                smtp.Port = 587;

                smtp.Send(mail);

                TempData["Email"] = "Sent";

                return RedirectToAction((string)Session["Department"]+"_Chat", "Doctor");
            }
        }
        public ActionResult ViewProblem()
        {
            if (Session["DoctorId"] != null)
            {
                string department = (string)Session["Department"];

                return View(dc.Problems.Where(m => m.Division.Equals(department)).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = dc.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        [HttpPost]
        [ActionName("Details")]
        public ActionResult SendEmail(string To, string Subject, string Body, HttpPostedFileBase fileUploader)
        {

            if (ModelState.IsValid)
            {

                string from = "onlineservice92@gmail.com";

                using (MailMessage mail = new MailMessage(from, To))
                {

                    mail.Subject = Subject;

                    mail.Body = Body;

                    if (fileUploader != null)
                    {

                        string fileName = Path.GetFileName(fileUploader.FileName);

                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

                    }

                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.EnableSsl = true;

                    NetworkCredential networkCredential = new NetworkCredential(from, "apadat1992");

                    smtp.UseDefaultCredentials = true;

                    smtp.Credentials = networkCredential;

                    smtp.Port = 587;

                    smtp.Send(mail);

                    ViewBag.Message = "Sent";

                    return RedirectToAction("ViewProblem");

                }

            }

            else
            {

                return View();

            }

        }
        public ActionResult ViewReports(Report report)
        {

            if (Session["DoctorId"] != null || Session["UserId"] != null)
            {
                string department = (string)Session["Department"];
                var user = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department.Equals(department)).FirstOrDefault();
                if (user != null)
                {
                    int userid = user.UserId;
                    return View(dc.Reports.Where(m => m.UserId.Equals(userid) && m.Department.Equals(department)).ToList());
                }

                else
                {
                    return Content("No reports available!");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult End_Session()
        {

            string department = (string)Session["Department"];
            var check = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department.Equals(department)).FirstOrDefault();
            if (check != null)
            {
                dc.RoomUsers.Remove(check);
                dc.SaveChanges();
                TempData["clear_session"] = "Session cleared successfully!";
                return RedirectToAction(department + "_Chat", "Doctor");
            }
            else
            {
                TempData["clear_session"] = "There is no active session!";
                return RedirectToAction(department + "_Chat", "Doctor");
            }

        }
        public ActionResult Delete_Post(int id)
        {
            var find = dc.Problems.Find(id);
            dc.Problems.Remove(find);
            dc.SaveChanges();
            return RedirectToAction("viewproblem");
        }
        public ActionResult SideView()
        {
            return PartialView();
        }


    }
}
using E_Health.Models.Account;
using E_Health.Models.DataContext;
using E_Health.Models.UserInRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Controllers
{
    public class UserChatController : Controller
    {

        DoctorContext dc = new DoctorContext();
        //
        // GET: /Chat/


        public ActionResult Select_Department()
        {
            if (Session["PatientId"] != null)
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Skin_Department(Register register, RoomUser user)
        {
            if (Session["PatientId"] != null)
            {
                Session["PatientName"] = Session["UserName"];
                Session["User_Dept"] = "Skin";
                int id = (int)Session["UserId"];
                var busy = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department.Contains("Skin")).FirstOrDefault();
                if (busy == null)
                {
                    var time = new DateTime();
                    var date = time.Hour;
                    var check = dc.Registers.Where(m => m.UserId == id).FirstOrDefault();

                    user.UserId = check.UserId;
                    user.Email = check.Email.ToString();
                    user.Time = time.ToString();
                    user.Department = "Skin";
                    user.Busy = "true";

                    dc.RoomUsers.Add(user);
                    dc.SaveChanges();


                    return View();
                }
                else
                {
                    if (busy.UserId == id)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Busy"] = "Doctor is busy now.Please try again later";
                        return RedirectToAction("Select_Department", "UserChat");
                    }

                }
            }

            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult Medicine_Department(RoomUser user)
        {
            if (Session["PatientId"] != null)
            {
                Session["PatientName"] = Session["UserName"];
                Session["User_Dept"] = "Medicine";
                int id = (int)Session["UserId"];
                var busy = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department == "Medicine").FirstOrDefault();
                if (busy == null)
                {
                    var time = new DateTime();
                    var date = time.Hour;
                    var check = dc.Registers.Where(m => m.UserId == id).FirstOrDefault();

                    user.UserId = check.UserId;
                    user.Email = check.Email.ToString();
                    user.Time = time.ToString();
                    user.Department = "Medicine";
                    user.Busy = "true";

                    dc.RoomUsers.Add(user);
                    dc.SaveChanges();


                    return View();
                }
                else
                {
                    if (busy.UserId == id)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Busy"] = "Doctor is busy now.Please try again later";
                        return RedirectToAction("Select_Department", "UserChat");
                    }

                }
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Neurology_Department(RoomUser user)
        {
            if (Session["PatientId"] != null)
            {
                Session["PatientName"] = Session["UserName"];
                Session["User_Dept"] = "Neurology";
                int id = (int)Session["UserId"];
                var busy = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department == "Neurology").FirstOrDefault();
                if (busy == null)
                {
                    var time = new DateTime();
                    var date = time.Hour;
                    var check = dc.Registers.Where(m => m.UserId == id).FirstOrDefault();

                    user.UserId = check.UserId;
                    user.Email = check.Email.ToString();
                    user.Time = time.ToString();
                    user.Department = "Neurology";
                    user.Busy = "true";

                    dc.RoomUsers.Add(user);
                    dc.SaveChanges();


                    return View();
                }
                else
                {
                    if (busy.UserId == id)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Busy"] = "Doctor is busy now.Please try again later";
                        return RedirectToAction("Select_Department", "UserChat");
                    }

                }
            }

            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }


        public ActionResult Cardiology_Department(RoomUser user)
        {
            if (Session["PatientId"] != null)
            {
                Session["PatientName"] = Session["UserName"];
                Session["User_Dept"] = "Cardiology";
                int id = (int)Session["UserId"];
                var busy = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department == "Cardiology").FirstOrDefault();
                if (busy == null)
                {
                    var time = new DateTime();
                    var date = time.Hour;
                    var check = dc.Registers.Where(m => m.UserId == id).FirstOrDefault();

                    user.UserId = check.UserId;
                    user.Email = check.Email.ToString();
                    user.Time = time.ToString();
                    user.Department = "Cardiology";
                    user.Busy = "true";

                    dc.RoomUsers.Add(user);
                    dc.SaveChanges();


                    return View();
                }
                else
                {
                    if (busy.UserId == id)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Busy"] = "Doctor is busy now.Please try again later";
                        return RedirectToAction("Select_Department", "UserChat");
                    }

                }
            }

            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult Gynaecology_Department(RoomUser user)
        {
            if (Session["PatientId"] != null)
            {
                Session["PatientName"] = Session["UserName"];
                Session["User_Dept"] = "Gynaecology";
                int id = (int)Session["UserId"];
                var busy = dc.RoomUsers.Where(m => m.Busy == "true" && m.Department == "Gynaecology").FirstOrDefault();
                if (busy == null)
                {
                    var time = new DateTime();
                    var date = time.Hour;
                    var check = dc.Registers.Where(m => m.UserId == id).FirstOrDefault();

                    user.UserId = check.UserId;
                    user.Email = check.Email.ToString();
                    user.Time = time.ToString();
                    user.Department = "Gynaecology";
                    user.Busy = "true";

                    dc.RoomUsers.Add(user);
                    dc.SaveChanges();


                    return View();
                }
                else
                {
                    if (busy.UserId == id)
                    {
                        return View();
                    }
                    else
                    {
                        TempData["Busy"] = "Doctor is busy now.Please try again later";
                        return RedirectToAction("Select_Department", "UserChat");
                    }

                }
            }

            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login", "Account");
            }

        }
        public ActionResult UserChat_SideView()
        {
            return View();
        }

    }
}
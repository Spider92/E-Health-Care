using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Health.Models;
using E_Health.Models.Doctor;
using E_Health.Models.DataContext;
using System.IO;
using System.Data.Entity;
using System.Net;
namespace E_Health.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        DoctorContext dc = new DoctorContext();

        public ActionResult Index()
        {
            if(Session["AdminId"]!=null)
            {
                return View();
            }
            else
            {
                TempData["not_login"] = "False";
                return RedirectToAction("Login","Account");
            }
        }
       
        public ActionResult AdminSideView()
        {
            return PartialView();
        }
        
        public ActionResult AdminSideView_Info()
        {
            return PartialView();
        }

    }
}
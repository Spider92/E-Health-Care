using E_Health.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Health.Controllers
{

    public class HomeController : Controller
    {
        DoctorContext dc = new DoctorContext();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Doctors_Photo()
        {
            return PartialView(dc.Docs.ToList());
        }
    }
}
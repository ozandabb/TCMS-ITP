using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class StudentProfileController : Controller
    {
        // GET: StudentProfile
        public ActionResult StudentProfile()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("loginStudent" , "Home");

            }
            else
            {
                return View();
            }
            

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("loginStudent" , "Home");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Attendance()
        {
            return View();
        }
    }
}
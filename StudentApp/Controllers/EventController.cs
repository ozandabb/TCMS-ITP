using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class EventController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Event
        public ActionResult Index(string searching)
        {
            return View(_db.Students.Where(x => x.Full_Name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult GetData()
        {
            return View();
        }

       
    }
}
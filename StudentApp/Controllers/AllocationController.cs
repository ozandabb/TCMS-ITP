using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TMSApp.Controllers
{
    public class AllocationController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Allocation
        public ActionResult Index(string Day, string S_Time, string E_Time, string C_id)
        {

            var allocations = from m in _db.Allocations
                              select m;


            if (!String.IsNullOrEmpty(S_Time) && !String.IsNullOrEmpty(E_Time) && !String.IsNullOrEmpty(C_id) && !String.IsNullOrEmpty(Day))
            {
                allocations = allocations.Where(s => (s.start_time.Contains(S_Time)) && (s.class_id.Contains(C_id)) && (s.day.Contains(Day)) && (s.end_time.Contains(E_Time)));

            }

            if (!String.IsNullOrEmpty(Day))
            {
                allocations = allocations.Where(s => s.day.Contains(Day));

            }
            if (!String.IsNullOrEmpty(C_id))
            {
                allocations = allocations.Where(s => s.class_id.Contains(C_id));

            }
            if (!String.IsNullOrEmpty(S_Time))
            {
                allocations = allocations.Where(s => s.start_time.Contains(S_Time));

            }
            if (!String.IsNullOrEmpty(E_Time))
            {
                allocations = allocations.Where(s => s.end_time.Contains(E_Time));

            }
            return View(allocations);


        }



        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]  Allocation AllocationToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Allocations.Add(AllocationToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Allocation/Edit/5
        public ActionResult Edit(int id)
        {

            var allocationToEdit = (from c in _db.Allocations
                                    where c.ca_id == id
                                    select c).First();
            return View(allocationToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Allocation allocationToEdit)
        {
            var originalAllocation = (from c in _db.Allocations
                                      where c.ca_id == allocationToEdit.ca_id
                                      select c).First();

            if (!ModelState.IsValid)
                return View(originalAllocation);

            _db.Entry(originalAllocation).CurrentValues.SetValues(allocationToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Allocation allocation = _db.Allocations.Find(id);


            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {

            Allocation allocation = _db.Allocations.Find(id);

            _db.Allocations.Remove(allocation);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Allocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocation allocation = _db.Allocations.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }
    }
}

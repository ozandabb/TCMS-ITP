using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class TeacherController : Controller
    {

        private TCMSDBEntities _db = new TCMSDBEntities();
        // GET: Teacher
        public ActionResult TeacherView(string searching)
        {
            return View(_db.teachers.Where(x => x.full_name.Contains(searching) || searching == null).ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            var teacherDetais = (from m in _db.teachers
                                 where m.t_id == id
                                 select m).First();
            return View(teacherDetais);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] teacher teacherToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.teachers.Add(teacherToCreate);
            try
            {
                _db.SaveChanges();
            }
            catch {

                Console.WriteLine();
            }
            

            return RedirectToAction("TeacherView");
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            var teacherToEdit = (from m in _db.teachers
                                 where m.t_id == id
                                 select m).First();
            return View(teacherToEdit);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(teacher teacherToEdit)
        {
            try
            {
                var originalTeacher = (from m in _db.teachers
                                       where m.t_id == teacherToEdit.t_id
                                       select m).First();

                if (!ModelState.IsValid)
                    return View(originalTeacher);

                _db.Entry(originalTeacher).CurrentValues.SetValues(teacherToEdit);
                _db.SaveChanges();

                return RedirectToAction("TeacherView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("TeacherView");
            }
            teacher teacherToDelete = _db.teachers.Find(id);
            if (teacherToDelete == null)
            {
                return HttpNotFound();
            }
            return View(teacherToDelete);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
                teacher teacherToDelete = _db.teachers.Find(id);
                _db.teachers.Remove(teacherToDelete);
                _db.SaveChanges();
                return RedirectToAction("TeacherView");
           
            
        }
    }
}

﻿using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class SubjectsController : Controller
    {
        private TCMSDBEntities _db = new TCMSDBEntities();

        // GET: Subjects
        public ActionResult SubjectView(string search)
        {
            var subjects = from sub in _db.subjects select sub;

            if (!String.IsNullOrEmpty(search))
            {
                subjects = subjects.Where(s => s.title.Contains(search));
            }

            return View(subjects);

        }

        // GET: Subjects/Details/5
        public ActionResult Details(int id)
        {
            var subjectDetail = (from s in _db.subjects
                                 where s.sub_id == id
                                 select s).First();
            return View(subjectDetail);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "sub_id")] subject subjectToCreate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _db.subjects.Add(subjectToCreate);
                _db.SaveChanges();

                return RedirectToAction("SubjectView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var subjectToEdit = (from m in _db.subjects
                                 where m.sub_id == id
                                 select m).First();
            return View(subjectToEdit);
        }


        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(subject subjectToEdit)
        {
            var originalSubject = (from m in _db.subjects
                                   where m.sub_id == subjectToEdit.sub_id
                                   select m).First();

            if (!ModelState.IsValid)
                return View(originalSubject);

            _db.Entry(originalSubject).CurrentValues.SetValues(subjectToEdit);
            _db.SaveChanges();

            return RedirectToAction("SubjectView");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SubjectView");
            }
            subject sbjectToDelete = _db.subjects.Find(id);
            if (sbjectToDelete == null)
            {
                return HttpNotFound();
            }
            return View(sbjectToDelete);


        }


        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            subject sbjectToDelete = _db.subjects.Find(id);
            _db.subjects.Remove(sbjectToDelete);
            _db.SaveChanges();
            return RedirectToAction("SubjectView");

        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using collectible_figures.Models;

namespace collectible_figures.Controllers
{
    public class ClassificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();       

        public JsonResult DoesNameExists(string name) {
            return Json(!db.Classifications.Any(x => x.Name == name), JsonRequestBehavior.AllowGet);
        }

        // GET: Classifications
        [Route("typ")]
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }

        // GET: Classifications/Details/5
        [Route("typ/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.Classifications.Find(id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

        // GET: Classifications/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassificationID,Name")] Classification classification)
        {
            if (ModelState.IsValid)
            {
                db.Classifications.Add(classification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classification);
        }

        // GET: Classifications/Edit/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.Classifications.Find(id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

        // POST: Classifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassificationID,Name")] Classification classification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classification);
        }

        // GET: Classifications/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.Classifications.Find(id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

        // POST: Classifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classification classification = db.Classifications.Find(id);
            db.Classifications.Remove(classification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

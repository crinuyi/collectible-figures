using System;
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
    public class FiguresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Figures
        public ActionResult Index()
        {
            var figures = db.Figures.Include(f => f.Classification).Include(f => f.Series);
            return View(figures.ToList());
        }

        // GET: Figures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure figure = db.Figures.Find(id);
            if (figure == null)
            {
                return HttpNotFound();
            }
            return View(figure);
        }

        // GET: Figures/Create
        public ActionResult Create()
        {
            ViewBag.ClassificationID = new SelectList(db.Classifications, "ClassificationID", "Name");
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "Name");
            return View();
        }

        // POST: Figures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FigureID,Name,Scale,ReleaseDate,Price,ClassificationID,SeriesID")] Figure figure)
        {
            if (ModelState.IsValid)
            {
                db.Figures.Add(figure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassificationID = new SelectList(db.Classifications, "ClassificationID", "Name", figure.ClassificationID);
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "Name", figure.SeriesID);
            return View(figure);
        }

        // GET: Figures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure figure = db.Figures.Find(id);
            if (figure == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassificationID = new SelectList(db.Classifications, "ClassificationID", "Name", figure.ClassificationID);
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "Name", figure.SeriesID);
            return View(figure);
        }

        // POST: Figures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FigureID,Name,Scale,ReleaseDate,Price,ClassificationID,SeriesID")] Figure figure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(figure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassificationID = new SelectList(db.Classifications, "ClassificationID", "Name", figure.ClassificationID);
            ViewBag.SeriesID = new SelectList(db.Series, "SeriesID", "Name", figure.SeriesID);
            return View(figure);
        }

        // GET: Figures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Figure figure = db.Figures.Find(id);
            if (figure == null)
            {
                return HttpNotFound();
            }
            return View(figure);
        }

        // POST: Figures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Figure figure = db.Figures.Find(id);
            db.Figures.Remove(figure);
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

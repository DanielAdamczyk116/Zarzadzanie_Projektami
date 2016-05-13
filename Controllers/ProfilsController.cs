using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zarzadzanie_Projektami.DAL;
using Zarzadzanie_Projektami.Models;
using PagedList;

namespace Zarzadzanie_Projektami.Controllers
{
    public class ProfilsController : Controller
    {
        private ProjektContext db = new ProjektContext();

        // GET: Profils
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var profil = from s in db.Profil
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                profil = profil.Where(s => s.Imie.Contains(searchString)
                                       || s.Login.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    profil = profil.OrderByDescending(s => s.Imie);
                    break;
                case "Date":
                    profil = profil.OrderBy(s => s.DataUtworzeniaKonta);
                    break;
                case "date_desc":
                    profil = profil.OrderByDescending(s => s.DataUtworzeniaKonta);
                    break;
                default:
                    profil = profil.OrderBy(s => s.Login);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(profil.ToPagedList(pageNumber, pageSize));
        }

        // GET: Profils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // GET: Profils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Login,Imie,Nazwisko,DataUtworzeniaKonta")] Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Profil.Add(profil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profil);
        }

        // GET: Profils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: Profils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Login,Imie,Nazwisko,DataUtworzeniaKonta")] Profil profil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profil);
        }

        // GET: Profils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profil profil = db.Profil.Find(id);
            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }

        // POST: Profils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profil profil = db.Profil.Find(id);
            db.Profil.Remove(profil);
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

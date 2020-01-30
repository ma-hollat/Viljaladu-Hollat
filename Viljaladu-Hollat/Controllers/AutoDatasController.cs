using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Viljaladu_Hollat.Models;

namespace Viljaladu_Hollat.Controllers
{
    public class AutoDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AutoDatas
        public ActionResult Index()
        {
            return View(db.AutoDatas.ToList());
        }
        public ActionResult ViljaladuAndmed()
        {
            return View(db.AutoDatas.ToList());
        }

        // GET: AutoDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoData autoData = db.AutoDatas.Find(id);
            if (autoData == null)
            {
                return HttpNotFound();
            }
            return View(autoData);
        }

        public ActionResult Import()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View();
        }


        // GET: AutoDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult LisaAndmed()
        {
            return View();
        }

        // POST: AutoDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,autonr,sisenemismass,lahkumismass")] AutoData autoData)
        {
            if (ModelState.IsValid)
            {
                db.AutoDatas.Add(autoData);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View(autoData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LisaAndmed([Bind(Include = "id,autonr,sisenemismass,lahkumismass")] AutoData autoData)
        {
            if (ModelState.IsValid)
            {
                db.AutoDatas.Add(autoData);
                db.SaveChanges();
                return RedirectToAction("ViljaladuAndmed");
            }

            return View(autoData);
        }


        // GET: AutoDatas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoData autoData = db.AutoDatas.Find(id);
            if (autoData == null)
            {
                return HttpNotFound();
            }
            return View(autoData);
        }

        // POST: AutoDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,autonr,sisenemismass,lahkumismass")] AutoData autoData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Export([Bind(Include = "id,autonr,sisenemismass,lahkumismass")] AutoData autoData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViljaladuAndmed");
            }
            return View(autoData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import([Bind(Include = "id,autonr,sisenemismass,lahkumismass")] AutoData autoData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViljaladuAndmed");
            }
            return View(autoData);
        }

        // GET: AutoDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoData autoData = db.AutoDatas.Find(id);
            if (autoData == null)
            {
                return HttpNotFound();
            }
            return View(autoData);
        }

        // POST: AutoDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoData autoData = db.AutoDatas.Find(id);
            db.AutoDatas.Remove(autoData);
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

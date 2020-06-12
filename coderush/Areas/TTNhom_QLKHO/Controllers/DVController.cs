using coderush.Areas.TTNhom_QLKHO.Models;
using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLKHO
{
    public class DVController : Controller
    {
        DBQLKHOContext db = new DBQLKHOContext();

        // GET: TTNhom_QLNS/group_role
        public ActionResult Index()
        {
            return View(db.DONVIs.ToList());
        }

        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVI group_role = db.DONVIs.Find(id);
            if (group_role == null)
            {
                return HttpNotFound();
            }
            return View(group_role);
        }

        // GET: TTNhom_QLNS//Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLNS/DV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TEN")] DONVI group_role)
        {
            if (ModelState.IsValid)
            {
                db.DONVIs.Add(group_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group_role);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVI group_role = db.DONVIs.Find(id);
            if (group_role == null)
            {
                return HttpNotFound();
            }
            return View(group_role);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TEN")] DONVI group_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group_role);
        }

        public ActionResult Delete(int? id)
        {
            DONVI group_role = db.DONVIs.Find(id);
            db.DONVIs.Remove(group_role);
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
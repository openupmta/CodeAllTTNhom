using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLNS.Models;

namespace coderush.Areas.TTNhom_QLNS.Controllers
{
    public class PositionsController : Controller
    {
        private DBQLNSContext db = new DBQLNSContext();

        // GET: TTNhom_QLNS/Positions
        public ActionResult Index()
        {
            return View(db.positions.ToList());
        }

        // GET: TTNhom_QLNS/Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            position position = db.positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: TTNhom_QLNS/Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLNS/Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pos_id,pos_name,pos_description,pos_status")] position position)
        {
            if (ModelState.IsValid)
            {
                db.positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: TTNhom_QLNS/Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            position position = db.positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: TTNhom_QLNS/Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pos_id,pos_name,pos_description,pos_status")] position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: TTNhom_QLNS/Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            position position = db.positions.Find(id);
            db.positions.Remove(position);
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

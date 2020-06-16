using coderush.Areas.TTNhom_QLKHO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLKHO.Controllers
{
    public class PXController : Controller
    {
        DBQLKHOContext db = new DBQLKHOContext();

        // GET: TTNhom_QLNS/group_role
        public ActionResult Index()
        {
            return View(db.PHIEUXUATs.ToList());
        }

        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUXUAT group_role = db.PHIEUXUATs.Find(id);
            if (group_role == null)
            {
                return HttpNotFound();
            }
            return View(group_role);
        }

        // GET: TTNhom_QLNS/group_role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLNS/group_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NGAYXUAT,IDTTPHIEUXUAT")] PHIEUXUAT group_role)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUXUATs.Add(group_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group_role);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUXUAT group_role = db.PHIEUXUATs.Find(id);
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
        public ActionResult Edit([Bind(Include = "ID,NGAYXUAT,IDTTPHIEUXUAT")] PHIEUXUAT group_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group_role);
        }

        public ActionResult Delete(string id)
        {
           PHIEUXUAT group_role = db.PHIEUXUATs.Find(id);
            db.PHIEUXUATs.Remove(group_role);
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
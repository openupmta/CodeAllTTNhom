using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;


namespace coderush.Areas.TTNhom_QLTTHPT.Controllers
{
    public class KhoiLopController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/KhoiLop
        public ActionResult Index()
        {
            List<KHOILOP> res = db.KHOILOPs.ToList();
            return View(res);
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOILOP KHOILOP = db.KHOILOPs.Find(ID);
            if (KHOILOP == null)
            {
                return HttpNotFound();
            }
            return View(KHOILOP);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenKhoi")] KHOILOP KHOILOP)
        {
            
            if (ModelState.IsValid)
            {
                db.KHOILOPs.Add(KHOILOP);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(KHOILOP);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOILOP KHOILOPdg = db.KHOILOPs.Find(id);
            if (KHOILOPdg == null)
            {
                return HttpNotFound();
            }
            return View(KHOILOPdg);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoi,TenKhoi")] KHOILOP KHOILOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(KHOILOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(KHOILOP);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                KHOILOP KHOILOP = db.KHOILOPs.Find(id);
                db.KHOILOPs.Remove(KHOILOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View("Error");
            }
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
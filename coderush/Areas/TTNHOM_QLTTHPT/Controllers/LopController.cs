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
    public class LopController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/Lop
        public ActionResult Index()
        {
            List<LOP> res = db.LOPs.ToList();
            return View(res);
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP LOP = db.LOPs.Find(ID);
            if (LOP == null)
            {
                return HttpNotFound();
            }
            return View(LOP);
        }

        public ActionResult Create()
        {
            var LOP = db.KHOILOPs.ToList();
            SelectList listKL = new SelectList(LOP, "MaKhoi", "TenKhoi");
            ViewBag.CatagoryKL = listKL;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenLop,MaKhoi")] LOP LOP)
        {
            var KL = db.KHOILOPs.ToList();
            SelectList listKL = new SelectList(KL, "MaKhoi", "TenKhoi");
            ViewBag.CatagoryKL = listKL;
            if (ModelState.IsValid)
            {
                db.LOPs.Add(LOP);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(LOP);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var LOP = db.KHOILOPs.ToList();
            SelectList listKL = new SelectList(LOP, "MaKhoi", "TenKhoi");
            ViewBag.CatagoryKL = listKL;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP LOPdg = db.LOPs.Find(id);
            if (LOPdg == null)
            {
                return HttpNotFound();
            }
            return View(LOPdg);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,MaKhoi")] LOP LOP)
        {
            var KL = db.KHOILOPs.ToList();
            SelectList listKL = new SelectList(KL, "MaKhoi", "TenKhoi");
            ViewBag.CatagoryKL = listKL;
            if (ModelState.IsValid)
            {
                db.Entry(LOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(LOP);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                LOP LOP = db.LOPs.Find(id);
                db.LOPs.Remove(LOP);
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
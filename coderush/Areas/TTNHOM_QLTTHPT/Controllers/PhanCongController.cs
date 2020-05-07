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
    public class PhanCongController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/PhanCong
        public ActionResult Index()
        {
            List<PHANCONG> res = db.PHANCONGs.ToList();
            return View(res);
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONG PHANCONG = db.PHANCONGs.Find(ID);
            if (PHANCONG == null)
            {
                return HttpNotFound();
            }
            return View(PHANCONG);
        }

        public ActionResult Create()
        {
            var GV = db.GIAOVIENs.ToList();
            SelectList listGV = new SelectList(GV, "MaGV", "HoTenGV");
            ViewBag.CatagoryGV = listGV;
            var Lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(Lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,MaGV,CongViec,NamHoc,SoTiet")] PHANCONG PHANCONG)
        {
            var GV = db.GIAOVIENs.ToList();
            SelectList listGV = new SelectList(GV, "MaGV", "HoTenGV");
            ViewBag.CatagoryGV = listGV;
            var Lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(Lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            if (ModelState.IsValid)
            {
                db.PHANCONGs.Add(PHANCONG);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(PHANCONG);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var GV = db.GIAOVIENs.ToList();
            SelectList listGV = new SelectList(GV, "MaGV", "HoTenGV");
            ViewBag.CatagoryGV = listGV;
            var Lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(Lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHANCONG PHANCONGdg = db.PHANCONGs.Find(id);
            if (PHANCONGdg == null)
            {
                return HttpNotFound();
            }
            return View(PHANCONGdg);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPC,MaLop,MaGV,CongViec,NamHoc,SoTiet")] PHANCONG PHANCONG)
        {
            var GV = db.GIAOVIENs.ToList();
            SelectList listGV = new SelectList(GV, "MaGV", "HoTenGV");
            ViewBag.CatagoryGV = listGV;
            var Lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(Lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            if (ModelState.IsValid)
            {
                db.Entry(PHANCONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(PHANCONG);
        }

        public ActionResult Delete(int? id)
        {
            PHANCONG PHANCONG = db.PHANCONGs.Find(id);
            db.PHANCONGs.Remove(PHANCONG);
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
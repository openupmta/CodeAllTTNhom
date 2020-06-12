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
    public class MonHocController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/MonHoc
        public ActionResult Index()
        {
            List<MONHOC> res = db.MONHOCs.ToList();
            return View(res);
        }

        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC MONHOC = db.MONHOCs.Find(ID);
            if (MONHOC == null)
            {
                return HttpNotFound();
            }
            return View(MONHOC);
        }

        public ActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenMH,KhoiMH")] MONHOC MONHOC)
        {
            
            if (ModelState.IsValid)
            {
                db.MONHOCs.Add(MONHOC);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(MONHOC);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONHOC MONHOCdg = db.MONHOCs.Find(id);
            if (MONHOCdg == null)
            {
                return HttpNotFound();
            }
            return View(MONHOCdg);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,KhoiMH")] MONHOC MONHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(MONHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(MONHOC);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                MONHOC MONHOC = db.MONHOCs.Find(id);
                db.MONHOCs.Remove(MONHOC);
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
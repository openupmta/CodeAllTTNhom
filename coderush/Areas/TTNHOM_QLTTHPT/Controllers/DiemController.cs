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
    public class DiemController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/Diem
        public ActionResult Index()
        {
            List<DIEM> res = db.DIEMs.ToList();
            return View(res);
        }

        public ActionResult Details(int? ID)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEM diem = db.DIEMs.Find(ID);
            if(diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        public ActionResult Create()
        {
            var diem = db.HOCSINHs.ToList();
            SelectList listHS = new SelectList(diem, "MaHS", "HoTenHS");
            ViewBag.CatagoryHS = listHS;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="DiemTBHK,DiemTK,HocKy,HanhKiem,NamHoc,HocLuc,MaHS")] DIEM diem)
        {
            var diemHS = db.HOCSINHs.ToList();
            SelectList listHS = new SelectList(diemHS, "MaHS", "HoTenHS");
            ViewBag.CatagoryHS = listHS;
            if(ModelState.IsValid)
            {
                db.DIEMs.Add(diem);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(diem);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var diem = db.HOCSINHs.ToList();
            SelectList listHS = new SelectList(diem, "MaHS", "HoTenHS");
            ViewBag.CatagoryHS = listHS;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEM diemdg = db.DIEMs.Find(id);
            if (diemdg == null)
            {
                return HttpNotFound();
            }
            return View(diemdg);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDiem,DiemTBHK,DiemTK,HocKy,HanhKiem,NamHoc,HocLuc,MaHS")] DIEM diem)
        {
            var diemdg = db.HOCSINHs.ToList();
            SelectList listHS = new SelectList(diemdg, "MaHS", "HoTenHS");
            ViewBag.CatagoryHS = listHS;
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diem);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                DIEM diem = db.DIEMs.Find(id);
                db.DIEMs.Remove(diem);
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
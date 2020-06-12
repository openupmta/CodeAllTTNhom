using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;
using static System.Net.Mime.MediaTypeNames;

namespace coderush.Areas.TTNhom_QLTTHPT.Controllers
{
    public class DiemChiTietController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();
        // GET: TTNhom_QLTT2HPT/DiemChiTiet
        public ActionResult Index()
        {
            List<DIEMCHITIETMONHOC> res = db.DIEMCHITIETMONHOCs.ToList();
            return View(res);
        }

        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEMCHITIETMONHOC diem = db.DIEMCHITIETMONHOCs.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: TTNhom_QLNS/group_role/Create
        public ActionResult Create()
        {
            var diemCTMH = db.MONHOCs.ToList();
            SelectList list = new SelectList(diemCTMH, "MaMH", "TenMH");
            ViewBag.CatagoryMH = list;
            var diem = db.DIEMs.ToList();
            SelectList listD = new SelectList(diem, "MaDiem", "MaDiem");
            ViewBag.CatagoryD = listD;
            return View();
        }

        // POST: TTNhom_QLNS/group_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiemMieng1,DiemMieng2,Diem15,Diem45,DiemThi,DiemTBMH,NgayNhap,MaMH,MaDiem")] DIEMCHITIETMONHOC diemct)
        {
            var diemCTMH = db.MONHOCs.ToList();
            SelectList list = new SelectList(diemCTMH, "MaMH", "TenMH");
            ViewBag.CatagoryMH = list;
            var diem = db.DIEMs.ToList();
            SelectList listD = new SelectList(diem, "MaDiem", "MaDiem");
            ViewBag.CatagoryD = listD;
            if (ModelState.IsValid)
            {
                db.DIEMCHITIETMONHOCs.Add(diemct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diemct);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var diemCTMH = db.MONHOCs.ToList();
            SelectList list = new SelectList(diemCTMH, "MaMH", "TenMH");
            ViewBag.CatagoryMH = list;
            var diem = db.DIEMs.ToList();
            SelectList listD = new SelectList(diem, "MaDiem", "MaDiem");
            ViewBag.CatagoryD = listD;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIEMCHITIETMONHOC diemct = db.DIEMCHITIETMONHOCs.Find(id);
            if (diemct == null)
            {
                return HttpNotFound();
            }
            return View(diemct);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDiemCTMH,DiemMieng1,DiemMieng2,Diem15,Diem45,DiemThi,DiemTBMH,NgayNhap,MaMH,MaDiem")] DIEMCHITIETMONHOC diem)
        {
            var diemCTMH = db.MONHOCs.ToList();
            SelectList list = new SelectList(diemCTMH, "MaMH", "TenMH");
            ViewBag.CatagoryMH = list;
            var diemct = db.DIEMs.ToList();
            SelectList listD = new SelectList(diemct, "MaDiem", "MaDiem");
            ViewBag.CatagoryD = listD;
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
            DIEMCHITIETMONHOC diem = db.DIEMCHITIETMONHOCs.Find(id);
            db.DIEMCHITIETMONHOCs.Remove(diem);
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
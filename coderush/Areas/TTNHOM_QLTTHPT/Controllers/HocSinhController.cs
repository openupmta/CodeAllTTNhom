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
    public class HocSinhController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/HocSinh
        public ActionResult Index()
        {
            List<HOCSINH> res = db.HOCSINHs.ToList();
            return View(res);
        }
        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH diem = db.HOCSINHs.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: TTNhom_QLNS/group_role/Create
        public ActionResult Create()
        {
            var lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            var DUT = db.DIENUUTIENs.ToList();
            SelectList listDut = new SelectList(DUT, "MaDUT", "TenDUT");
            ViewBag.CatagoryDut = listDut;
            return View();
        }

        // POST: TTNhom_QLNS/group_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoTenHS,GioiTinh,NgaySinh,DiaChi,SDT,NienKhoa,DanToc,TonGiao,MaLop,MaDUT")] HOCSINH dienut)
        {
            var lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            var DUT = db.DIENUUTIENs.ToList();
            SelectList listDut = new SelectList(DUT, "MaDUT", "TenDUT");
            ViewBag.CatagoryDut = listDut;
            if (ModelState.IsValid)
            {
                db.HOCSINHs.Add(dienut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dienut);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            var DUT = db.DIENUUTIENs.ToList();
            SelectList listDut = new SelectList(DUT, "MaDUT", "TenDUT");
            ViewBag.CatagoryDut = listDut;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH diemct = db.HOCSINHs.Find(id);
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
        public ActionResult Edit([Bind(Include = "MaHS,HoTenHS,GioiTinh,NgaySinh,DiaChi,SDT,NienKhoa,DanToc,TonGiao,MaLop,MaDUT")] HOCSINH diem)
        {
            var lop = db.LOPs.ToList();
            SelectList listLop = new SelectList(lop, "MaLop", "TenLop");
            ViewBag.CatagoryLop = listLop;
            var DUT = db.DIENUUTIENs.ToList();
            SelectList listDut = new SelectList(DUT, "MaDUT", "TenDUT");
            ViewBag.CatagoryDut = listDut;
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
            HOCSINH diem = db.HOCSINHs.Find(id);
            db.HOCSINHs.Remove(diem);
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
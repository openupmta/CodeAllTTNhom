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
    public class GiaoVienController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/GiaoVien
        public ActionResult Index()
        {
            List<GIAOVIEN> res = db.GIAOVIENs.ToList();
            return View(res);
        }
        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN diem = db.GIAOVIENs.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: TTNhom_QLNS/group_role/Create
        public ActionResult Create()
        {
            var gv = db.MONHOCs.ToList();
            SelectList listMH = new SelectList(gv, "MaMH", "TenMH");
            ViewBag.CatagoryMH = listMH;
            return View();
        }

        // POST: TTNhom_QLNS/group_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoTenGV,GioiTinh,DiaChi,NgaySinh,SDT,MaHT,MaMH,Luong")] GIAOVIEN dienut)
        {
            var gv = db.MONHOCs.ToList();
            SelectList listMH = new SelectList(gv, "MaMH", "TenMH");
            ViewBag.CatagoryMH = listMH;
            if (ModelState.IsValid)
            {
                db.GIAOVIENs.Add(dienut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dienut);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            var gv = db.MONHOCs.ToList();
            SelectList listMH = new SelectList(gv, "MaMH", "TenMH");
            ViewBag.CatagoryMH = listMH;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN diemct = db.GIAOVIENs.Find(id);
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
        public ActionResult Edit([Bind(Include = "MaGV,HoTenGV,GioiTinh,NgaySinh,DiaChi,SDT,MaHT,MaMH,Luong")] GIAOVIEN diem)
        {
            var gv = db.MONHOCs.ToList();
            SelectList listMH = new SelectList(gv, "MaMH", "TenMH");
            ViewBag.CatagoryMH = listMH;
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
            GIAOVIEN diem = db.GIAOVIENs.Find(id);
            db.GIAOVIENs.Remove(diem);
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
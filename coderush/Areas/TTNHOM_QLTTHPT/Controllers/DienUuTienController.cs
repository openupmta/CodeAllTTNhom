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
    public class DienUuTienController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();
        // GET: TTNhom_QLTTHPT/DienUuTien
        public ActionResult Index()
        {
            List<DIENUUTIEN> res = db.DIENUUTIENs.ToList();
            return View(res);
        }
        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENUUTIEN diem = db.DIENUUTIENs.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
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
        public ActionResult Create([Bind(Include = "TenDUT")] DIENUUTIEN dienut)
        {
            if (ModelState.IsValid)
            {
                db.DIENUUTIENs.Add(dienut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dienut);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIENUUTIEN diemct = db.DIENUUTIENs.Find(id);
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
        public ActionResult Edit([Bind(Include = "MaDUT,TenDUT")] DIENUUTIEN diem)
        {
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
                DIENUUTIEN diem = db.DIENUUTIENs.Find(id);
                db.DIENUUTIENs.Remove(diem);
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
using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class PublishingCompanyController : Controller
    {
        DBQLTVContext db = new DBQLTVContext();

        // GET: TTNhom_QLThuVien/PublishingCompany
        public ActionResult Index()
        {
            return View(db.NhaXuatBans.ToList());
        }

        // GET: TTNhom_QLThuVien/PublishingCompany/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan obj = db.NhaXuatBans.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // GET: TTNhom_QLThuVien/PublishingCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLThuVien/PublishingCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNXB, TenNXB, DiaChi, Email, SoDT, GhiChu")] NhaXuatBan obj)
        {
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: TTNhom_QLThuVien/PublishingCompany/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaXuatBan obj = db.NhaXuatBans.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: TTNhom_QLThuVien/PublishingCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNXB, TenNXB, DiaChi, Email, SoDT, GhiChu")] NhaXuatBan obj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(string id)
        {
            try
            {
                NhaXuatBan obj = db.NhaXuatBans.Find(id);
                db.NhaXuatBans.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
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
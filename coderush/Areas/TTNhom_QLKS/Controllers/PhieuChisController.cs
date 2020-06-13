using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLKS.Dom;
using coderush.Areas.TTNhom_QLKS.EF;

namespace coderush.Areas.TTNhom_QLKS.Controllers
{
    public class PhieuChisController : Controller
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/PhieuChis
        public ActionResult Index()
        {           
            var phieuChis = db.PhieuChis.Include(p => p.MucChi).Include(p => p.NhanVien);
            return View(phieuChis.ToList());
        }

        // GET: TTNhom_QLKS/PhieuChis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuChi);
        }

        // GET: TTNhom_QLKS/PhieuChis/Create
        public ActionResult Create()
        {
            ViewBag.maMucChi = new SelectList(db.MucChis, "maMucChi", "mucchi1");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV");
            return View();
        }

        // POST: TTNhom_QLKS/PhieuChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPC,diengiai,tongtien,ngaytao,maMucChi,maNV")] PhieuChi phieuChi)
        {
            if (ModelState.IsValid)
            {
                db.PhieuChis.Add(phieuChi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maMucChi = new SelectList(db.MucChis, "maMucChi", "mucchi1", phieuChi.maMucChi);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuChi.maNV);
            return View(phieuChi);
        }

        // GET: TTNhom_QLKS/PhieuChis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.maMucChi = new SelectList(db.MucChis, "maMucChi", "mucchi1", phieuChi.maMucChi);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuChi.maNV);
            return View(phieuChi);
        }

        // POST: TTNhom_QLKS/PhieuChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPC,diengiai,tongtien,ngaytao,maMucChi,maNV")] PhieuChi phieuChi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuChi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maMucChi = new SelectList(db.MucChis, "maMucChi", "mucchi1", phieuChi.maMucChi);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuChi.maNV);
            return View(phieuChi);
        }
              
       

        // POST: TTNhom_QLKS/PhieuChis/Delete/5
       [HttpDelete]
        public ActionResult Delete(int? id)
        {
            new PhieuChiDom().Delete(id);
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

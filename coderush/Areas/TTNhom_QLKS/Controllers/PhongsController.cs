

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLKS.EF;

namespace coderush.Areas.TTNhom_QLKS.Controllers
{
    public class PhongsController : Controller
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/Phongs
        public ActionResult Index()
        {
            var phongs = db.Phongs.Include(p => p.LoaiPhong).Include(p => p.TrangThaiPhong);
            return View(phongs.ToList());
        }

        

        // GET: TTNhom_QLKS/Phongs/Create
        public ActionResult Create()
        {
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "maLP", "tenLP");
            ViewBag.maTTP = new SelectList(db.TrangThaiPhongs, "maTTP", "tenTTP");
            return View();
        }

        // POST: TTNhom_QLKS/Phongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maphong,sophong,maLP,maTTP,songuoi,lau")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLP = new SelectList(db.LoaiPhongs, "maLP", "tenLP", phong.maLP);
            ViewBag.maTTP = new SelectList(db.TrangThaiPhongs, "maTTP", "tenTTP", phong.maTTP);
            return View(phong);
        }

        // GET: TTNhom_QLKS/Phongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "maLP", "tenLP", phong.maLP);
            ViewBag.maTTP = new SelectList(db.TrangThaiPhongs, "maTTP", "tenTTP", phong.maTTP);
            return View(phong);
        }

        // POST: TTNhom_QLKS/Phongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maphong,sophong,maLP,maTTP,songuoi,lau")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "maLP", "tenLP", phong.maLP);
            ViewBag.maTTP = new SelectList(db.TrangThaiPhongs, "maTTP", "tenTTP", phong.maTTP);
            return View(phong);
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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

        // show gia phong
        public ActionResult IndexDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var giaphong = db.GiaPhongs.ToList().Where(gp =>gp.maphong == id);
            if (giaphong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDphong = id;
            return PartialView(giaphong);
        }


        [HttpDelete]
        public ActionResult DeleteDV(int? IDdichvu, int? IDphong)
        {

            GiaPhong giaPhong = db.GiaPhongs.Find(IDdichvu, IDphong);
            db.GiaPhongs.Remove(giaPhong);
            db.SaveChanges();
            return RedirectToAction("Index", "Phongs");
        }

    }
}

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
    public class GiaPhongsController : Controller
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/GiaPhongs
        public ActionResult Index()
        {
            var giaPhongs = db.GiaPhongs.Include(g => g.DichVu).Include(g => g.Phong);
            return View(giaPhongs.ToList());
        }

 
        

        // GET: TTNhom_QLKS/GiaPhongs/Create
        public ActionResult Create(int? maphong)
        {
            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV");
            if (maphong == null)
            {
                ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong");
            }
            else
            {
                ViewBag.maphong = maphong;
                ViewBag.sophong = db.Phongs.Find(maphong).sophong;
            }
            
            return View();
        }

        // POST: TTNhom_QLKS/GiaPhongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maDV,maphong,gia")] GiaPhong giaPhong)
        {
            if (ModelState.IsValid)
            {
                db.GiaPhongs.Add(giaPhong);
                db.SaveChanges();
                return RedirectToAction("Index", "Phongs");
            }

            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV", giaPhong.maDV);
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong", giaPhong.maphong);
            return RedirectToAction("Index","Phongs");
        }

        // GET: TTNhom_QLKS/GiaPhongs/Edit/5
        public ActionResult Edit(int? IDdichvu, int? IDphong)
        {
            if (IDdichvu == null || IDphong == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaPhong giaPhong = db.GiaPhongs.Find(IDdichvu, IDphong);
            if (giaPhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.sophong = db.Phongs.Find(giaPhong.maphong).sophong;
            ViewBag.tenDV = db.DichVus.Find(giaPhong.maDV).tenDV;
            return View(giaPhong);
        }

        // POST: TTNhom_QLKS/GiaPhongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maDV,maphong,gia")] GiaPhong giaPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit","Phongs", new { @id = giaPhong.maphong });
            }
            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV", giaPhong.maDV);
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong", giaPhong.maphong);
            return View(giaPhong);
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

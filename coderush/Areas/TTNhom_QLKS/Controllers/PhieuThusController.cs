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
    public class PhieuThusController : BaseController
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/PhieuThus
        public ActionResult Index()
        {
            var phieuThus = db.PhieuThus.Include(p => p.DichVu).Include(p => p.HinhThucTT).Include(p => p.KhachHang).Include(p => p.NhanVien).Include(p => p.Phong);
            return View(phieuThus.ToList());
        }

        // GET: TTNhom_QLKS/PhieuThus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            return View(phieuThu);
        }

        // GET: TTNhom_QLKS/PhieuThus/Create
        public ActionResult Create()
        {
            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV");
            ViewBag.maHinhThucTT = new SelectList(db.HinhThucTTs, "maHinhThucTT", "hinhthucTT1");
            ViewBag.cmt = new SelectList(db.KhachHangs, "cmt", "tenKH");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV");
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "sophong");
            return View();
        }

        // POST: TTNhom_QLKS/PhieuThus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPT,ngaytao,thoigianvao,thoigianra,khuyenmai,tratruoc,tongtien,trangthaiTT,maNV,maphong,maDV,cmt,maHinhThucTT")] PhieuThu phieuThu)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThus.Add(phieuThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV", phieuThu.maDV);
            ViewBag.maHinhThucTT = new SelectList(db.HinhThucTTs, "maHinhThucTT", "hinhthucTT1", phieuThu.maHinhThucTT);
            ViewBag.cmt = new SelectList(db.KhachHangs, "cmt", "tenKH", phieuThu.cmt);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThu.maNV);
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong", phieuThu.maphong);
            return View(phieuThu);
        }

        // GET: TTNhom_QLKS/PhieuThus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV", phieuThu.maDV);
            ViewBag.maHinhThucTT = new SelectList(db.HinhThucTTs, "maHinhThucTT", "hinhthucTT1", phieuThu.maHinhThucTT);
            ViewBag.cmt = new SelectList(db.KhachHangs, "cmt", "tenKH", phieuThu.cmt);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThu.maNV);
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong", phieuThu.maphong);
            return View(phieuThu);
        }

        // POST: TTNhom_QLKS/PhieuThus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPT,ngaytao,thoigianvao,thoigianra,khuyenmai,tratruoc,tongtien,trangthaiTT,maNV,maphong,maDV,cmt,maHinhThucTT")] PhieuThu phieuThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDV = new SelectList(db.DichVus, "maDV", "tenDV", phieuThu.maDV);
            ViewBag.maHinhThucTT = new SelectList(db.HinhThucTTs, "maHinhThucTT", "hinhthucTT1", phieuThu.maHinhThucTT);
            ViewBag.cmt = new SelectList(db.KhachHangs, "cmt", "tenKH", phieuThu.cmt);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThu.maNV);
            ViewBag.maphong = new SelectList(db.Phongs, "maphong", "maphong", phieuThu.maphong);
            return View(phieuThu);
        }

        // GET: TTNhom_QLKS/PhieuThus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            if (phieuThu == null)
            {
                return HttpNotFound();
            }
            return View(phieuThu);
        }

        // POST: TTNhom_QLKS/PhieuThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuThu phieuThu = db.PhieuThus.Find(id);
            db.PhieuThus.Remove(phieuThu);
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

        public ActionResult IndexDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PhieuThu_DichVuChung = db.PhieuThu_DichVuChung.ToList().Where(dpt => dpt.maPT == id);
            if (PhieuThu_DichVuChung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDphieuthu = id;
            return PartialView(PhieuThu_DichVuChung);
        }

        [HttpDelete]
        public ActionResult DeleteDVC(int? @IDphieuthu, int? @IDdvc)
        {

            PhieuThu_DichVuChung pt_dvc = db.PhieuThu_DichVuChung.Find(@IDphieuthu, @IDdvc);
            db.PhieuThu_DichVuChung.Remove(pt_dvc);
            db.SaveChanges();
            return RedirectToAction("Edit", "PhieuThu", new { @id = @IDphieuthu });
        }
    }
}

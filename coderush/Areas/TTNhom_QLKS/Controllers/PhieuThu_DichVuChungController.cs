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
    public class PhieuThu_DichVuChungController : Controller
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/PhieuThu_DichVuChung
        public ActionResult Index()
        {
            var phieuThu_DichVuChung = db.PhieuThu_DichVuChung.Include(p => p.DichVuChung).Include(p => p.PhieuThu);
            return View(phieuThu_DichVuChung.ToList());
        }

        // GET: TTNhom_QLKS/PhieuThu_DichVuChung/Details/5
        
        // GET: TTNhom_QLKS/PhieuThu_DichVuChung/Create
        public ActionResult Create(int? maPT)
        {
            ViewBag.maDVC = new SelectList(db.DichVuChungs, "maDVC", "tenDVC");
            if (maPT == null)
            {
                ViewBag.maPT = new SelectList(db.PhieuThus, "maPT", "cmt");
            }
            else
            {
                ViewBag.PhieuThu = db.PhieuThus.Where(p => p.maPT== maPT).Include(p => p.DichVu).Include(p => p.HinhThucTT).Include(p => p.KhachHang).Include(p => p.NhanVien).Include(p => p.Phong).First();
            }
            //ViewBag.PhieuThu = db.PhieuThus.Find(maPT);
            return View();
        }

        // POST: TTNhom_QLKS/PhieuThu_DichVuChung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPT,maDVC,soluong,hethan,tongtienDVC")] PhieuThu_DichVuChung phieuThu_DichVuChung)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThu_DichVuChung.Add(phieuThu_DichVuChung);
                db.SaveChanges();
                return RedirectToAction("Edit", "PhieuThus", new { @id = phieuThu_DichVuChung.maPT });
            }

            ViewBag.maDVC = new SelectList(db.DichVuChungs, "maDVC", "tenDVC", phieuThu_DichVuChung.maDVC);
            ViewBag.maPT = new SelectList(db.PhieuThus, "maPT", "cmt", phieuThu_DichVuChung.maPT);
            return RedirectToAction("Edit", "PhieuThus", new { @id = phieuThu_DichVuChung.maPT });
        }

        // GET: TTNhom_QLKS/PhieuThu_DichVuChung/Edit/5
        public ActionResult Edit(int? @IDphieuthu, int? IDdvc)
        {
            if (@IDphieuthu == null || @IDdvc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThu_DichVuChung phieuThu_DichVuChung = db.PhieuThu_DichVuChung.Find(@IDphieuthu, IDdvc);
            if (phieuThu_DichVuChung == null)
            {
                return HttpNotFound();
            }
            ViewBag.tenDVC = db.DichVuChungs.Find(IDdvc).tenDVC;
            ViewBag.PhieuThu = db.PhieuThus.Where(p => p.maPT == @IDphieuthu).Include(p => p.DichVu).Include(p => p.HinhThucTT).Include(p => p.KhachHang).Include(p => p.NhanVien).Include(p => p.Phong).First();
            return View(phieuThu_DichVuChung);
        }

        // POST: TTNhom_QLKS/PhieuThu_DichVuChung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPT,maDVC,soluong,hethan,tongtienDVC")] PhieuThu_DichVuChung phieuThu_DichVuChung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThu_DichVuChung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "PhieuThus", new { @id = phieuThu_DichVuChung.maPT });
            }
            ViewBag.maDVC = new SelectList(db.DichVuChungs, "maDVC", "tenDVC", phieuThu_DichVuChung.maDVC);
            ViewBag.maPT = new SelectList(db.PhieuThus, "maPT", "cmt", phieuThu_DichVuChung.maPT);
            return View(phieuThu_DichVuChung);
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

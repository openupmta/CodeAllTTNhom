using ClosedXML.Excel;
using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class ReadersController : Controller
    {
        DBQLTVContext db = new DBQLTVContext();

        // GET: TTNhom_QLThuVien/Book
        public ActionResult Index()
        {
            return View(db.DocGias.ToList());
        }

        // GET: TTNhom_QLThuVien/Book/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia obj = db.DocGias.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // GET: TTNhom_QLThuVien/Book/Create
        public ActionResult Create()
        {
            List<TacGia> author = db.TacGias.ToList();
            return View();
        }

        // POST: TTNhom_QLThuVien/Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDocGia, TenDocGia, DonVi, SoDT, DiaChi, CMT, MaSoThe")] DocGia obj, [Bind(Include = "MaSoThe, NgayCap, NgayHetHan, GhiChu")] TheThuVien obj2)
        {
            if (ModelState.IsValid)
            {
                db.TheThuViens.Add(obj2);
                db.DocGias.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: TTNhom_QLThuVien/Book/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia obj = db.DocGias.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: TTNhom_QLThuVien/Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDocGia, TenDocGia, DonVi, SoDT, DiaChi, CMT, MaSoThe")] DocGia obj, [Bind(Include = "MaSoThe, NgayCap, NgayHetHan, GhiChu")] TheThuVien obj2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obj2).State = EntityState.Modified;
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
                DocGia obj = db.DocGias.Find(id);
                TheThuVien obj2 = db.TheThuViens.Find(obj.MaSoThe);
                db.DocGias.Remove(obj);
                db.TheThuViens.Remove(obj2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult ExportToExcel(string id)
        {
            DocGia obj = db.DocGias.Find(id);

            XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("newSheet");

            worksheet.Cell(1, 1).SetValue("THẺ THƯ VIỆN");
            worksheet.Cell(3, 1).SetValue("Mã độc giả: " + obj.MaDocGia);
            worksheet.Cell(4, 1).SetValue("Tên độc giả: " + obj.TenDocGia);
            worksheet.Cell(5, 1).SetValue("Đơn vị: " + obj.DonVi);
            worksheet.Cell(6, 1).SetValue("Mã số thẻ: " + obj.MaSoThe);
            worksheet.Cell(7, 1).SetValue("Số điện thoại: " + obj.SoDT);
            worksheet.Cell(8, 1).SetValue("Địa chỉ: " + obj.DiaChi);
            worksheet.Cell(9, 1).SetValue("CMT/CCDC: " + obj.CMT);
            worksheet.Cell(11, 1).SetValue("Thẻ thư viện khi tạo mới có thời hạn 1 năm.");
            worksheet.Cell(12, 1).SetValue("Sau 1 năm nếu độc giả có nhu cầu tiếp tục sử dụng có thể đăng ký gia hạn thẻ.");
            worksheet.Cell(14, 1).SetValue("Thư viện Học viện Kỹ thuật Quân sự");

            MemoryStream MS = new MemoryStream();
            workbook.SaveAs(MS);
            MS.Position = 0;

            return new FileStreamResult(MS, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            { FileDownloadName = "Example.xlsx" };
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
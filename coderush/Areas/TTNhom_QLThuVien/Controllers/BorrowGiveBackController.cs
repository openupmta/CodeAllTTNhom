using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ClosedXML.Excel;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class BorrowGiveBackController : Controller
    {
        DBQLTVContext db = new DBQLTVContext();

        // GET: TTNhom_QLThuVien/BorrowGiveBack
        public ActionResult Index()
        {
            return View(db.MuonTraSaches.ToList());
        }

        public ActionResult Index2()
        {
            var data = from bg in db.MuonTraSaches
                       where bg.DaTra == false
                       select bg;
            return View(data.ToList());
        }

        public ActionResult Index3()
        {
            var data = from bg in db.MuonTraSaches
                       where bg.DaTra == true
                       select bg;
            return View(data.ToList());
        }

        // GET: TTNhom_QLThuVien/BorrowGiveBack/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuonTraSach obj = db.MuonTraSaches.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // GET: TTNhom_QLThuVien/BorrowGiveBack/Create
        public ActionResult Create()
        {
            List<TheThuVien> card = db.TheThuViens.ToList();
            List<Sach> book = db.Saches.ToList();
            SelectList cardList = new SelectList(card, "MaSoThe", "MaSoThe", "MaSoThe");
            SelectList bookList = new SelectList(book, "MaSach", "TenSach", "MaSach");
            ViewBag.CardList = cardList;
            ViewBag.BookList = bookList;
            return View();
        }

        // POST: TTNhom_QLThuVien/BorrowGiveBack/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMuonTra, MaSoThe, MaSach, NgayMuonSach, HanTraSach, TinhTrangKhiMuon, DaTra, NgayTraSach, TinhTrangKhiTra, GhiChu")] MuonTraSach obj)
        {
            if (ModelState.IsValid)
            {
                obj.DaTra = false;
                db.MuonTraSaches.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: TTNhom_QLThuVien/BorrowGiveBack/Edit/5
        public ActionResult Edit(string id)
        {
            List<TheThuVien> card = db.TheThuViens.ToList();
            List<Sach> book = db.Saches.ToList();
            SelectList cardList = new SelectList(card, "MaSoThe", "MaSoThe", "MaSoThe");
            SelectList bookList = new SelectList(book, "MaSach", "TenSach", "MaSach");
            ViewBag.CardList = cardList;
            ViewBag.BookList = bookList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuonTraSach obj = db.MuonTraSaches.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: TTNhom_QLThuVien/BorrowGiveBack/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMuonTra, MaSoThe, MaSach, NgayMuonSach, HanTraSach, TinhTrangKhiMuon, DaTra, NgayTraSach, TinhTrangKhiTra, GhiChu")] MuonTraSach obj)
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
                MuonTraSach obj = db.MuonTraSaches.Find(id);
                db.MuonTraSaches.Remove(obj);
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
            MuonTraSach obj = db.MuonTraSaches.Find(id);

            XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("newSheet");

            worksheet.Cell(1, 1).SetValue("PHIẾU MƯỢN SÁCH");
            worksheet.Cell(3, 1).SetValue("Mã mượ trả: " + obj.MaMuonTra);
            worksheet.Cell(4, 1).SetValue("Mã số thẻ: " + obj.MaSoThe);
            worksheet.Cell(5, 1).SetValue("Mã sách: " + obj.MaSach);
            worksheet.Cell(6, 1).SetValue("Tên sách: " + obj.Sach.TenSach);
            worksheet.Cell(7, 1).SetValue("Ngày mượn sách: " + obj.NgayMuonSach.Value.ToShortDateString());
            worksheet.Cell(8, 1).SetValue("Hạn trả sách: " + obj.HanTraSach.Value.ToShortDateString());
            worksheet.Cell(9, 1).SetValue("Tình trạng khi mượn: " + obj.TinhTrangKhiMuon);
            worksheet.Cell(10, 1).SetValue("Ghi chú: " + obj.GhiChu);
            worksheet.Cell(12, 1).SetValue("Yêu cầu bạn đọc giữ gìn sách cẩn thận, trả sách đúng hạn.");
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
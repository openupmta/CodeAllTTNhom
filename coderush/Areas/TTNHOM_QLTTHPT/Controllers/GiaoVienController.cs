using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;
using OfficeOpenXml;

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
            try
            {
                GIAOVIEN diem = db.GIAOVIENs.Find(id);
                db.GIAOVIENs.Remove(diem);
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

        public void ExportToExcel()
        {
            List<GIAOVIEN> emplist = db.GIAOVIENs.ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["D1"].Value = "Danh Sách Giáo Viên";

            ws.Cells["C3"].Value = "Ngày Tạo :";
            ws.Cells["D3"].Value = string.Format("{0:dd MM yyyy} at {0:H: mm tt}", DateTime.Now);

            ws.Cells["A6"].Value = "STT";
            ws.Cells["B6"].Value = "Họ và Tên";
            ws.Cells["C6"].Value = "Giới Tính";
            ws.Cells["D6"].Value = "Ngày Sinh";
            ws.Cells["E6"].Value = "Địa Chỉ";
            ws.Cells["F6"].Value = "Số Điện Thoại";
            ws.Cells["G6"].Value = "Dạy Môn";
            ws.Cells["H6"].Value = "Lương";

            int rowStart = 7;
            int stt = 1;
            foreach (var item in emplist)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = stt;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.HoTenGV;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.GioiTinh;
                ws.Cells[string.Format("D{0}", rowStart)].Value = string.Format("{0:dd/MM/yyyy}", item.NgaySinh);
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.DiaChi;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.SDT;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.MONHOC.TenMH;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Luong;
                rowStart++;
                stt++;
            }


            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}
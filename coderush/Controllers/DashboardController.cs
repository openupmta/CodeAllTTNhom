using coderush.Areas.TTNhom_QLKHO.Models;
using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;
using OfficeOpenXml;
using coderush.Areas.TTNhom_QLNS.Models;
using coderush.Areas.TTNhom_QLKS.EF;

namespace coderush.Controllers
{
    public class DashboardController : Controller
    {
        QuanLyTTHPTConText dbTHPTcontext = new QuanLyTTHPTConText();
        public ActionResult Dashboardv1()
        {
            //QUẢN LÝ THPT
            List<DIEM> hs = dbTHPTcontext.DIEMs.ToList();
            ViewBag.HocSinh = hs;

            ViewBag.totalStudent = (from s in dbTHPTcontext.HOCSINHs select s).Count();
            ViewBag.totalStudentXS = (from s in dbTHPTcontext.DIEMs where s.HocLuc == "Xuất Sắc" select s).Count();
            ViewBag.totalStudentG = (from s in dbTHPTcontext.DIEMs where s.HocLuc == "Giỏi" select s).Count();
            ViewBag.totalStudentK = (from s in dbTHPTcontext.DIEMs where s.HocLuc == "Khá" select s).Count();
            ViewBag.totalStudentTB = (from s in dbTHPTcontext.DIEMs where s.HocLuc == "Trung Bình" select s).Count();
            ViewBag.totalStudentY = (from s in dbTHPTcontext.DIEMs where s.HocLuc == "Yếu" select s).Count();
            ViewBag.totalStudentDUT = (from s in dbTHPTcontext.HOCSINHs where s.MaDUT != 1 select s).Count();
            ViewBag.totalTeacher = (from t in dbTHPTcontext.HOCSINHs select t).Count();
            ViewBag.totalClass = (from c in dbTHPTcontext.HOCSINHs select c).Count();

            // QL_NhanSu
            DBQLNSContext dBQLNS = new DBQLNSContext();
            ViewBag.TotalStaffON = dBQLNS.staffs.Where(x => x.sta_status == 1).Count();
            ViewBag.TotalStaffOFF = dBQLNS.staffs.Where(x => x.sta_status == 0).Count();
            var gr_admin = dBQLNS.group_role.Where(x => x.gr_name == "Admin").FirstOrDefault();
            var gr_user = dBQLNS.group_role.Where(x => x.gr_name == "User").FirstOrDefault();
            if (gr_admin != null)
                ViewBag.TotalQL = dBQLNS.staffs.Where(x => x.group_role_id == gr_admin.gr_id).Count();
            if (gr_user != null)
                ViewBag.TotalND = dBQLNS.staffs.Where(x => x.group_role_id == gr_user.gr_id).Count();


            // QL_ThuVien
            DBQLTVContext dbQLTV = new DBQLTVContext();
            var totalBook = (from b in dbQLTV.Saches
                             select b).Count();

            var totalCategory = (from c in dbQLTV.TheLoais
                                 select c).Count();

            var totalPublishingCompany = (from c in dbQLTV.NhaXuatBans
                                          select c).Count();

            var totalAuthor = (from a in dbQLTV.TacGias
                               select a).Count();

            var totalReader = (from r in dbQLTV.DocGias
                               select r).Count();

            var totalBG = (from bg in dbQLTV.MuonTraSaches
                           select bg).Count();

            var alreadyBG = (from bg in dbQLTV.MuonTraSaches
                             where bg.DaTra == true
                             select bg).Count();

            var yetBG = (from bg in dbQLTV.MuonTraSaches
                         where bg.DaTra == false
                         select bg).Count();

            ViewBag.TotalBook = totalBook;
            ViewBag.TotalCategory = totalCategory;
            ViewBag.TotalPublishingCompany = totalPublishingCompany;
            ViewBag.TotalAuthor = totalAuthor;
            ViewBag.TotalReader = totalReader;
            ViewBag.TotalBG = totalBG;
            ViewBag.AlreadyBG = alreadyBG;
            ViewBag.YetBG = yetBG;

            // QL_Kho
            DBQLKHOContext dbQLKHO = new DBQLKHOContext();
            var HH = (from b in dbQLKHO.HANGHOAs
                      select b).Count();

            var KH = (from c in dbQLKHO.KHACHHANGs
                      select c).Count();

            var NCC = (from c in dbQLKHO.NHACCs
                       select c).Count();

            var PN = (from a in dbQLKHO.PHIEUNHAPs
                      select a).Count();

            var PX = (from r in dbQLKHO.PHIEUXUATs
                      select r).Count();

            ViewBag.HH = HH;
            ViewBag.KH = KH;
            ViewBag.NCC = NCC;
            ViewBag.PN = PN;
            ViewBag.PX = PX;

            // QL_KhachSan

            QLKSdbContext dbQLKS = new QLKSdbContext();
            ViewBag.NhanVien = dbQLKS.NhanViens.Count();
            // số lượng khách hàng
            ViewBag.KhachHang = dbQLKS.KhachHangs.Count();
            // thu lãi ngày
            ViewBag.ThuNgay = Convert.ToDecimal((dbQLKS.PhieuThus.Where(p => p.ngaytao.Value.Day == DateTime.Now.Day).Sum(p => p.tongtien)));
            // chi tiề ngày
            ViewBag.ChiNgay = Convert.ToDecimal((dbQLKS.PhieuChis.Where(p => p.ngaytao.Value.Day == DateTime.Now.Day).Sum(p => p.tongtien)));
            // thu lãi tháng
            ViewBag.ThuThang = Convert.ToDecimal((dbQLKS.PhieuThus.Where(p => p.ngaytao.Value.Month == DateTime.Now.Month).Sum(p => p.tongtien)));
            // chi tiền tháng
            ViewBag.ChiThang = Convert.ToDecimal((dbQLKS.PhieuChis.Where(p => p.ngaytao.Value.Month == DateTime.Now.Month).Sum(p => p.tongtien)));

            // QL_TruongTHPT

            return View();
        }

        public void ExportToExcel()
        {
            List<DIEM> emplist = dbTHPTcontext.DIEMs.ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["D1"].Value = "ĐÁNH GIÁ HỌC LỰC HỌC SINH";

            ws.Cells["C3"].Value = "Ngày Tạo :";
            ws.Cells["D3"].Value = string.Format("{0:dd MM yyyy} at {0:H: mm tt}", DateTime.Now);

            ws.Cells["A6"].Value = "STT";
            ws.Cells["B6"].Value = "Họ và Tên";
            ws.Cells["C6"].Value = "Điểm TBHK";
            ws.Cells["D6"].Value = "Điểm TK";
            ws.Cells["E6"].Value = "Học Kỳ";
            ws.Cells["F6"].Value = "Hạnh Kiểm";
            ws.Cells["G6"].Value = "Năm Học";
            ws.Cells["H6"].Value = "Học Lực";

            int rowStart = 7;
            int stt = 1;
            foreach (var item in emplist)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = stt;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.HOCSINH.HoTenHS;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.DiemTBHK;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.DiemTK;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.HocKy;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.HanhKiem;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.NamHoc;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.HocLuc;
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

        public ActionResult Dashboardv2()
        {
            return View();
        }
    }
}
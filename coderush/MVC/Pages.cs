using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lte.MVC
{
    public static class Pages
    {
        public static class Dashboard
        {
            public const string dashboard = "/Dashboard/Dashboardv1";
        }
        
        public static class QuanLyTTHPT
        {
            public const string Home = "/TTNhom_QLTTHPT/Home/Index";
            public const string HocSinh = "/TTNhom_QLTTHPT/HocSinh/Index";
            public const string GiaoVien = "/TTNhom_QLTTHPT/GiaoVien/Index";
            public const string Diem = "/TTNhom_QLTTHPT/Diem/Index";
            public const string DiemChiTiet = "/TTNhom_QLTTHPT/DiemChiTiet/Index";
            public const string MonHoc = "/TTNhom_QLTTHPT/MonHoc/Index";
            public const string PhanCong = "/TTNhom_QLTTHPT/PhanCong/Index";
            public const string Lop = "/TTNhom_QLTTHPT/Lop/Index";
            public const string KhoiLop = "/TTNhom_QLTTHPT/KhoiLop/Index";
            public const string DienUuTien = "/TTNhom_QLTTHPT/DienUuTien/Index";
        }

        public static class QLTV
        {
            public const string Home = "/TTNhom_QLThuVien/Home/Index";
            public const string News = "/TTNhom_QLThuVien/News/Index";
            public const string WorkingSchedule = "/TTNhom_QLThuVien/WorkingSchedule/Index";
            public const string BorrowGiveBack = "/TTNhom_QLThuVien/BorrowGiveBack/Index";
            public const string Book = "/TTNhom_QLThuVien/Book/Index";
            public const string PublishingCompany = "/TTNhom_QLThuVien/PublishingCompany/Index";
            public const string Author = "/TTNhom_QLThuVien/Author/Index";
            public const string Category = "/TTNhom_QLThuVien/Category/Index";
            public const string Readers = "/TTNhom_QLThuVien/Readers/Index";
            public const string Rules = "/TTNhom_QLThuVien/Rules/Index";
        }
        public static class QLKHO
        {
            public const string Home = "/TTNhom_QLKHO/Home/Index";
            public const string News = "/TTNhom_QLKHO/News/Index";
            public const string HH = "/TTNhom_QLKHO/HH/Index";
            public const string KH = "/TTNhom_QLKHO/KH/Index";
            public const string DV = "/TTNhom_QLKHO/DV/Index";
            public const string NCC = "/TTNhom_QLKHO/NCC/Index";
            public const string PN = "/TTNhom_QLKHO/PN/Index";
            public const string TTPN = "/TTNhom_QLKHO/TTPN/Index";
            public const string PX = "/TTNhom_QLKHO/PX/Index";
            public const string TTPX = "/TTNhom_QLKHO/TTPX/Index";
        }


        public static class GroupRole
        {
            public const string Index = "/TTNhom_QLNS/group_role/Index";
            public const string Create = "/TTNhom_QLNS/group_role/Create";
            public const string Detail = "/TTNhom_QLNS/group_role/Details";
            public const string Update = "/TTNhom_QLNS/group_role/Edit";
            
        }
        public static class Department
        {
            public const string Index = "/TTNhom_QLNS/Departments/Index";
            public const string Create = "/TTNhom_QLNS/Departments/Create";
            public const string Detail = "/TTNhom_QLNS/Departments/Details";
            public const string Update = "/TTNhom_QLNS/Departments/Edit";
        }
        public static class Position
        {
            public const string Index = "/TTNhom_QLNS/Positions/Index";
            public const string Create = "/TTNhom_QLNS/Positions/Create";
            public const string Detail = "/TTNhom_QLNS/Positions/Details";
            public const string Update = "/TTNhom_QLNS/Positions/Edit";
        }
        public static class Staff
        {
            public const string Index = "/TTNhom_QLNS/Staffs/Index";
            public const string Create = "/TTNhom_QLNS/Staffs/Create";
            public const string Detail = "/TTNhom_QLNS/Staffs/Details";
            public const string Update = "/TTNhom_QLNS/Staffs/Edit";
        }

        public static class QLKS
        {
            public const string Home = "/TTNhom_QLKS/Home/Index";
            public const string Employees = "/TTNhom_QLKS/NhanViens/Index";
            public const string Payments = "/TTNhom_QLKS/PhieuChis/Index";
            public const string Clients = "/TTNhom_QLKS/KhachHangs/Index";
            public const string GeneralService = "/TTNhom_QLKS/DichVuChungs/Index";
            public const string Rooms = "/TTNhom_QLKS/Phongs/Index";
            public const string Receipts = "/TTNhom_QLKS/PhieuThus/Index";
        }
        public static class Dashbaordv2
        {
            public const string Url = "/Dashboard/Dashboardv1";
        }

        public static class LayoutTop
        {
            public const string Url = "/Layout/Top";
        }

        public static class LayoutBoxed
        {
            public const string Url = "/Layout/Boxed";
        }

        public static class LayoutFixed
        {
            public const string Url = "/Layout/Fixed";
        }

        public static class LayoutCollapsed
        {
            public const string Url = "/Layout/Collapsed";
        }

        public static class WidgetIndex
        {
            public const string Url = "/Widget/Index";
        }

        public static class ChartChartJS
        {
            public const string Url = "/Chart/ChartJS";
        }

        public static class ChartMorris
        {
            public const string Url = "/Chart/Morris";
        }

        public static class ChartFlot
        {
            public const string Url = "/Chart/Flot";
        }

        public static class ChartInline
        {
            public const string Url = "/Chart/Inline";
        }

        public static class UIElementGeneral
        {
            public const string Url = "/UIElement/General";
        }

        public static class UIElementIcon
        {
            public const string Url = "/UIElement/Icon";
        }

        public static class UIElementButton
        {
            public const string Url = "/UIElement/Button";
        }

        public static class UIElementSlider
        {
            public const string Url = "/UIElement/Slider";
        }

        public static class UIElementTimeline
        {
            public const string Url = "/UIElement/Timeline";
        }

        public static class UIElementModal
        {
            public const string Url = "/UIElement/Modal";
        }

        public static class FormGeneral
        {
            public const string Url = "/Form/General";
        }

        public static class FormAdvanced
        {
            public const string Url = "/Form/Advanced";
        }

        public static class FormEditor
        {
            public const string Url = "/Form/Editor";
        }

        public static class TableSimple
        {
            public const string Url = "/Table/Simple";
        }

        public static class TableData
        {
            public const string Url = "/Table/Data";
        }

        public static class CalendarIndex
        {
            public const string Url = "/Calendar/Index";
        }

        public static class MailboxIndex
        {
            public const string Url = "/Mailbox/Index";
        }

        public static class MailboxCompose
        {
            public const string Url = "/Mailbox/Compose";
        }

        public static class MailboxRead
        {
            public const string Url = "/Mailbox/Read";
        }

        public static class ExampleInvoice
        {
            public const string Url = "/Example/Invoice";
        }

        public static class ExampleInvoicePrint
        {
            public const string Url = "/Example/InvoicePrint";
        }

        public static class ExampleProfile
        {
            public const string Url = "/Example/Profile";
        }

        public static class ExampleLogin
        {
            public const string Url = "/Example/Login";
        }

        public static class ExampleRegister
        {
            public const string Url = "/Example/Register";
        }

        public static class ExampleLockscreen
        {
            public const string Url = "/Example/Lockscreen";
        }

        public static class ExampleError404
        {
            public const string Url = "/Example/Error404";
        }

        public static class ExampleError500
        {
            public const string Url = "/Example/Error500";
        }

        public static class ExampleBlankPage
        {
            public const string Url = "/Example/BlankPage";
        }

        public static class ExamplePacePage
        {
            public const string Url = "/Example/PacePage";
        }
        public static class Account
        {
            public const string Logout = "/Account/LogOff";
        }
    }
}
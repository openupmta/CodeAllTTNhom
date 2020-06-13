namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThu")]
    public partial class PhieuThu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuThu()
        {
            PhieuThu_DichVuChung = new HashSet<PhieuThu_DichVuChung>();
        }

        [Key]
        [Display(Name ="ID phiếu phu")]
        public int maPT { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? ngaytao { get; set; }

        [Display(Name = "Thời gian vào")]
        public DateTime? thoigianvao { get; set; }

        [Display(Name = "Thời gian ra")]
        public DateTime? thoigianra { get; set; }

        [Display(Name = "Khuyến mại")]
        public decimal? khuyenmai { get; set; }

        [Display(Name = "Trả trước")]
        public decimal? tratruoc { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? tongtien { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public bool trangthaiTT { get; set; }

        [Display(Name = "ID nhân viên")]
        public int? maNV { get; set; }

        [Display(Name = "ID phòng")]
        public int? maphong { get; set; }

        [Display(Name = "ID dịch vụ")]
        public int? maDV { get; set; }

        [StringLength(20)]
        [Display(Name = "CMT khách hàng")]
        public string cmt { get; set; }

        [Display(Name = "ID Hình thức thanh toán")]
        public int? maHinhThucTT { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu_DichVuChung> PhieuThu_DichVuChung { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

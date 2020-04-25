namespace QLKSCommonModels.EF
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
        public int maPT { get; set; }

        public DateTime ngaytao { get; set; }

        public DateTime? thoigianvao { get; set; }

        public DateTime? thoigianra { get; set; }

        public decimal? khuyenmai { get; set; }

        public decimal? tratruoc { get; set; }

        public decimal? tongtien { get; set; }

        [StringLength(100)]
        public string hinhthucTT { get; set; }

        public bool? trangthaiTT { get; set; }

        public int? soluong { get; set; }

        public byte maNV { get; set; }

        public byte maphong { get; set; }

        [Required]
        [StringLength(20)]
        public string loaiDV { get; set; }

        [Required]
        [StringLength(20)]
        public string cmt { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu_DichVuChung> PhieuThu_DichVuChung { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

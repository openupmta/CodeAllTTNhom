namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuChis = new HashSet<PhieuChi>();
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [Display(Name = "ID nhân viên")]
        public int maNV { get; set; }

        [StringLength(30)]
        [Display(Name = "Tên nhân viên")]
        public string tenNV { get; set; }

        [Display(Name = "Ca làm")]
        public string ca { get; set; }

        [Display(Name = "Lương")]
        public decimal? luong { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Mật khẩu")]
        public string matkhau { get; set; }

        [Display(Name = "Đăng nhập gần nhất")]
        public DateTime? dangnhapgannhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}

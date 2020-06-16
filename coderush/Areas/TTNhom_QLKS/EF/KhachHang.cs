namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name = "CMT")]
        public string cmt { get; set; }

        [StringLength(30)]
        [Display(Name = "Tên khách hàng")]
        public string tenKH { get; set; }

        [StringLength(11)]
        [Display(Name = "Điện thoại")]
        public string sdt { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? ngaytao { get; set; }

        [Display(Name = "Lần giao dịch")]
        public int? solangiaodich { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Mật khẩu")]
        public string matkhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}

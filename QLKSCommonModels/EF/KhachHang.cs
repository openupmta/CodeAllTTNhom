namespace QLKSCommonModels.EF
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
        public string cmt { get; set; }

        [StringLength(50)]
        public string taikhoan { get; set; }

        [StringLength(10)]
        public string matkhau { get; set; }

        [StringLength(30)]
        public string tenKH { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        public int? solangiaodich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}

namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVuChung")]
    public partial class DichVuChung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVuChung()
        {
            PhieuThu_DichVuChung = new HashSet<PhieuThu_DichVuChung>();
        }

        [Key]
        [Display(Name ="ID dịch vụ chung")]
        public int maDVC { get; set; }

        [StringLength(500)]
        [Display(Name ="Tên dịch vụ chung")]
        public string tenDVC { get; set; }

        [Display(Name = "Giá dịch vụ chung")]
        public decimal? giaDVC { get; set; }

        [StringLength(500)]
        [Display(Name = "Đơn vị tính")]
        public string donvitinhDVC { get; set; }

        [Display(Name = "Trạng thái")]
        public bool trangthaiDVC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu_DichVuChung> PhieuThu_DichVuChung { get; set; }
    }
}

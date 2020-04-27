namespace QLKSCommonModels.EF
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
        public int maDVC { get; set; }

        [StringLength(500)]
        public string tenDVC { get; set; }

        public decimal? giaDVC { get; set; }

        [StringLength(500)]
        public string donvitinhDVC { get; set; }

        public bool? trangthaiDVC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu_DichVuChung> PhieuThu_DichVuChung { get; set; }
    }
}

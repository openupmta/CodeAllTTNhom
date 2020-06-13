namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhThucTT")]
    public partial class HinhThucTT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HinhThucTT()
        {
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [Display(Name = "ID HTTT")]
        public int maHinhThucTT { get; set; }

        [Column("hinhthucTT")]
        [StringLength(100)]
        [Display(Name = "Loại hình thanh toán")]
        public string hinhthucTT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}

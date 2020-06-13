namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            DIEMs = new HashSet<DIEM>();
        }

        [Key]
        public int MaHS { get; set; }

        [StringLength(50)]
        public string HoTenHS { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string MaLT { get; set; }

        [StringLength(10)]
        public string MaBT { get; set; }

        [StringLength(10)]
        public string NienKhoa { get; set; }

        [StringLength(20)]
        public string DanToc { get; set; }

        public int? MaLop { get; set; }

        [StringLength(50)]
        public string TonGiao { get; set; }

        public int? MaDUT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEM> DIEMs { get; set; }

        public virtual DIENUUTIEN DIENUUTIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}

namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOVIEN()
        {
            PHANCONGs = new HashSet<PHANCONG>();
        }

        [Key]
        public int MaGV { get; set; }

        [StringLength(50)]
        public string HoTenGV { get; set; }

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string MaHT { get; set; }

        public int? MaMH { get; set; }

        public int? Luong { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONGs { get; set; }
    }
}

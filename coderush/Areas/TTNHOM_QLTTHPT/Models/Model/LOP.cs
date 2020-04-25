namespace coderush.Areas.TTNHOM_QLTTHPT.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            HOCSINHs = new HashSet<HOCSINH>();
            PHANCONGs = new HashSet<PHANCONG>();
        }

        [Key]
        [StringLength(10)]
        public string MaLop { get; set; }

        [StringLength(10)]
        public string TenLop { get; set; }

        [StringLength(10)]
        public string MaKhoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }

        public virtual KHOILOP KHOILOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONG> PHANCONGs { get; set; }
    }
}

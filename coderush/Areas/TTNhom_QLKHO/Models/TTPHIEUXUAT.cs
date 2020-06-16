namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTPHIEUXUAT")]
    public partial class TTPHIEUXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TTPHIEUXUAT()
        {
            PHIEUXUATs = new HashSet<PHIEUXUAT>();
        }

        public string ID { get; set; }

        [Required]
        [StringLength(128)]
        public string IDHH { get; set; }

        [Required]
        [StringLength(128)]
        public string IDTTPHIEUNHAP { get; set; }

        public int IDKH { get; set; }

        public int? COUNT { get; set; }

        public virtual HANGHOA HANGHOA { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUATs { get; set; }
    }
}

namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGHOA")]
    public partial class HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGHOA()
        {
            TTPHIEUNHAPs = new HashSet<TTPHIEUNHAP>();
            TTPHIEUXUATs = new HashSet<TTPHIEUXUAT>();
        }

        public string ID { get; set; }

        public string TENHH { get; set; }

        public int IDDV { get; set; }

        public int IDNCC { get; set; }

        public virtual DONVI DONVI { get; set; }

        public virtual NHACC NHACC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHIEUNHAP> TTPHIEUNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHIEUXUAT> TTPHIEUXUATs { get; set; }
    }
}

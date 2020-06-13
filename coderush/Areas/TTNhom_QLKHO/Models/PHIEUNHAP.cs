namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            TTPHIEUNHAPs = new HashSet<TTPHIEUNHAP>();
        }

        public string ID { get; set; }

        public DateTime? NGAYNHAP { get; set; }

        public int? IDTTPX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHIEUNHAP> TTPHIEUNHAPs { get; set; }
    }
}

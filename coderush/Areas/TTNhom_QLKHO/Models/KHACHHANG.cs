namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            TTPHIEUXUATs = new HashSet<TTPHIEUXUAT>();
            TTPHIEUNHAPs = new HashSet<TTPHIEUNHAP>();
        }

        public int ID { get; set; }

        public string DIACHI { get; set; }

        [StringLength(20)]
        public string PHONE { get; set; }

        [StringLength(200)]
        public string EMAIL { get; set; }

        public DateTime? NGAYTT { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHIEUXUAT> TTPHIEUXUATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHIEUNHAP> TTPHIEUNHAPs { get; set; }
    }
}

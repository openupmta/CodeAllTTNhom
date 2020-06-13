namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACC")]
    public partial class NHACC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACC()
        {
            HANGHOAs = new HashSet<HANGHOA>();
        }

        public int ID { get; set; }

        public string TENNCC { get; set; }

        public string DIACHI { get; set; }

        [StringLength(20)]
        public string PHONE { get; set; }

        [StringLength(200)]
        public string EMAIL { get; set; }

        public DateTime? NGAYHT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGHOA> HANGHOAs { get; set; }
    }
}

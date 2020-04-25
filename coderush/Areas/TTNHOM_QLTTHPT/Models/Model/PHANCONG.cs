namespace coderush.Areas.TTNHOM_QLTTHPT.Models.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANCONG")]
    public partial class PHANCONG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaLop { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaGV { get; set; }

        [StringLength(50)]
        public string CongViec { get; set; }

        [StringLength(50)]
        public string NamHoc { get; set; }

        public int? SoTiet { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}

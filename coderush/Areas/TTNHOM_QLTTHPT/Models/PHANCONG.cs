namespace coderush.Areas.TTNhom_QLTTHPT.Models
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
        public int MaPC { get; set; }

        public int MaLop { get; set; }

        public int MaGV { get; set; }

        [StringLength(50)]
        public string CongViec { get; set; }

        [StringLength(50)]
        public string NamHoc { get; set; }

        public int? SoTiet { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual LOP LOP { get; set; }
    }
}

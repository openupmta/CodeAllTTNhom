namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTPHIEUNHAP")]
    public partial class TTPHIEUNHAP
    {
        public string ID { get; set; }

        [Required]
        [StringLength(128)]
        public string IDHH { get; set; }

        [Required]
        [StringLength(128)]
        public string IDPHIEUNHAP { get; set; }

        public int? COUNT { get; set; }

        public double? GIANHAP { get; set; }

        public double? GIAXUAT { get; set; }

        public string STATUS { get; set; }

        public int? IDKH { get; set; }

        public virtual HANGHOA HANGHOA { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }
    }
}

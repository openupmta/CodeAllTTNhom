namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMCHITIETMONHOC")]
    public partial class DIEMCHITIETMONHOC
    {
        [Key]
        public int MaDiemCTMH { get; set; }

        public double? DiemMieng1 { get; set; }

        public double? DiemMieng2 { get; set; }

        public double? Diem15 { get; set; }

        public double? Diem45 { get; set; }

        public double? DiemThi { get; set; }

        public double? DiemTBMH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? MaMH { get; set; }

        public int? MaDiem { get; set; }

        public virtual DIEM DIEM { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}

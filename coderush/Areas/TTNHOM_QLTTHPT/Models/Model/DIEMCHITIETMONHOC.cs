namespace coderush.Areas.TTNHOM_QLTTHPT.Models.Model
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
        [StringLength(10)]
        public string MaDiemCTMH { get; set; }

        public double? DiemMieng1 { get; set; }

        public double? DiemMieng2 { get; set; }

        public double? Diem15 { get; set; }

        public double? Diem45 { get; set; }

        public double? DiemThi { get; set; }

        public double? DiemTBMH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [StringLength(10)]
        public string MaMH { get; set; }

        [StringLength(10)]
        public string MaDiem { get; set; }

        public virtual DIEM DIEM { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}

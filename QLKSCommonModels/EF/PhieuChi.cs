namespace QLKSCommonModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuChi")]
    public partial class PhieuChi
    {
        [Key]
        public int maPC { get; set; }

        [Column(TypeName = "ntext")]
        public string diengiai { get; set; }

        [StringLength(100)]
        public string mucchi { get; set; }

        public decimal? tongtien { get; set; }

        public DateTime ngaytao { get; set; }

        public byte maNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}

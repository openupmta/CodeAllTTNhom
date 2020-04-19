namespace coderush.Areas.TTNhom_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuonTraSach")]
    public partial class MuonTraSach
    {
        [Key]
        [StringLength(10)]
        public string MaMuonTra { get; set; }

        [StringLength(10)]
        public string MaSoThe { get; set; }

        [StringLength(10)]
        public string MaSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMuonSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanTraSach { get; set; }

        [StringLength(100)]
        public string TinhTrangKhiMuon { get; set; }

        public bool? DaTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraSach { get; set; }

        [StringLength(100)]
        public string TinhTrangKhiTra { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }
    }
}

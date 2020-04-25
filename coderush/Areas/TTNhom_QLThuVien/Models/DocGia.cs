namespace coderush.Areas.TTNhom_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocGia")]
    public partial class DocGia
    {
        [Key]
        [StringLength(10)]
        public string MaDocGia { get; set; }

        [StringLength(50)]
        public string TenDocGia { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        [StringLength(10)]
        public string MaSoThe { get; set; }

        [StringLength(11)]
        public string SoDT { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string CMT { get; set; }

        public virtual TheThuVien TheThuVien { get; set; }
    }
}

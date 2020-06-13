namespace coderush.Areas.TTNhom_QLKS.EF
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
        [Display(Name = "ID phiếu chi")]
        public int maPC { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name ="Diễn giải")]
        public string diengiai { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? tongtien { get; set; }

        [Display(Name = "Ngày tọa")]
        public DateTime? ngaytao { get; set; }

        [Display(Name = "Mục chỉ")]
        public int? maMucChi { get; set; }

        [Display(Name = "Nhân viên")]
        public int? maNV { get; set; }

        public virtual MucChi MucChi { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}

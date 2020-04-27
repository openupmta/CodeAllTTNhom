namespace QLKSCommonModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaPhong")]
    public partial class GiaPhong
    {
        public decimal? gia { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string loaiDV { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte maphong { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

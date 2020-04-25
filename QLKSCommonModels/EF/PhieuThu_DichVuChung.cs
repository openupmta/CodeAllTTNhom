namespace QLKSCommonModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhieuThu_DichVuChung
    {
        public int? soluong { get; set; }

        public DateTime? hethan { get; set; }

        public decimal? tongtienDVC { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maPT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maDVC { get; set; }

        public virtual DichVuChung DichVuChung { get; set; }

        public virtual PhieuThu PhieuThu { get; set; }
    }
}

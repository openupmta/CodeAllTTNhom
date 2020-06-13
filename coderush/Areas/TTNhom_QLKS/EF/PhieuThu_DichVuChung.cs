namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhieuThu_DichVuChung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID phiếu phu")]
        public int maPT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID Dịch vụ chung")]
        public int maDVC { get; set; }

        [Display(Name = "Số lượng")]
        public int? soluong { get; set; }

        [Display(Name = "Hết hạn")]
        public DateTime? hethan { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? tongtienDVC { get; set; }

        public virtual DichVuChung DichVuChung { get; set; }

        public virtual PhieuThu PhieuThu { get; set; }
    }
}

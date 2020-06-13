namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaPhong")]
    public partial class GiaPhong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID dịch vụ")]
        public int maDV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID phòng")]
        public int maphong { get; set; }

        [Display(Name = "Giá dịch vụ")]
        public decimal? gia { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

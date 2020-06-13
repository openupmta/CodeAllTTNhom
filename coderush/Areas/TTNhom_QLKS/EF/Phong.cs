namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            GiaPhongs = new HashSet<GiaPhong>();
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [Display(Name = "ID phòng")]
        public int maphong { get; set; }

        [Display(Name = "Số phòng")]
        public int? sophong { get; set; }

        [Display(Name = "ID loại phòng")]
        public byte? maLP { get; set; }

        [Display(Name = "ID trạng thái phòng")]
        public byte? maTTP { get; set; }

        [Display(Name = "Số người")]
        public byte? songuoi { get; set; }

        [Display(Name = "Lầu")]
        public byte? lau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiaPhong> GiaPhongs { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }

        public virtual TrangThaiPhong TrangThaiPhong { get; set; }
    }
}

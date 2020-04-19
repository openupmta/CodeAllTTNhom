namespace coderush.Areas.TTNhom_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            MuonTraSaches = new HashSet<MuonTraSach>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(100)]
        public string TenSach { get; set; }

        [StringLength(10)]
        public string MaTacGia { get; set; }

        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [StringLength(10)]
        public string MaNXB { get; set; }

        public int? NamXuatBan { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonTraSach> MuonTraSaches { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}

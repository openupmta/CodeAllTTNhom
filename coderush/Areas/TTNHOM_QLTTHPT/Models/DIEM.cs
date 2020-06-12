namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEM")]
    public partial class DIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIEM()
        {
            DIEMCHITIETMONHOCs = new HashSet<DIEMCHITIETMONHOC>();
        }

        [Key]
        public int MaDiem { get; set; }

        public double? DiemTBHK { get; set; }

        public double? DiemTK { get; set; }

        [StringLength(50)]
        public string HocKy { get; set; }

        [StringLength(50)]
        public string HanhKiem { get; set; }

        [StringLength(50)]
        public string NamHoc { get; set; }

        [StringLength(50)]
        public string HocLuc { get; set; }

        public int? MaHS { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMCHITIETMONHOC> DIEMCHITIETMONHOCs { get; set; }
    }
}

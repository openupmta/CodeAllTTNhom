namespace coderush.Areas.TTNhom_QLKS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MucChi")]
    public partial class MucChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MucChi()
        {
            PhieuChis = new HashSet<PhieuChi>();
        }

        [Key]
        [Display(Name = "ID mục chỉ")]
        public int maMucChi { get; set; }

        [Column("mucchi")]
        [StringLength(100)]
        [Display(Name = "Mục chỉ")]
        public string mucchi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
    }
}

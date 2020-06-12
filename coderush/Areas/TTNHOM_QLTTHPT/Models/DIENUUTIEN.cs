namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIENUUTIEN")]
    public partial class DIENUUTIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIENUUTIEN()
        {
            HOCSINHs = new HashSet<HOCSINH>();
        }

        [Key]
        public int MaDUT { get; set; }

        [StringLength(50)]
        public string TenDUT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }
    }
}

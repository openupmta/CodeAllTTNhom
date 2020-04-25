namespace coderush.Areas.TTNhom_QLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class group_role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public group_role()
        {
            staffs = new HashSet<staff>();
        }

        [Key]
        public int gr_id { get; set; }

        [Required]
        [StringLength(50)]
        public string gr_name { get; set; }

        [StringLength(500)]
        public string gr_description { get; set; }

        public byte? gr_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}

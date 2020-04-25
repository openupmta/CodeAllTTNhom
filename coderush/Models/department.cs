namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("department")]
    public partial class department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public department()
        {
            staffs = new HashSet<staff>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int de_id { get; set; }

        [StringLength(50)]
        public string de_name { get; set; }

        [StringLength(50)]
        public string de_thumbnail { get; set; }

        [StringLength(500)]
        public string de_description { get; set; }

        [StringLength(50)]
        public string de_manager { get; set; }

        public byte? de_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}

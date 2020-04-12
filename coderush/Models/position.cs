namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("position")]
    public partial class position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position()
        {
            staffs = new HashSet<staff>();
        }

        [Key]
        public int pos_id { get; set; }

        [StringLength(250)]
        public string pos_name { get; set; }

        [StringLength(250)]
        public string pos_competence { get; set; }

        [StringLength(250)]
        public string pos_abilty { get; set; }

        [StringLength(250)]
        public string pos_authority { get; set; }

        [StringLength(250)]
        public string pos_responsibility { get; set; }

        [StringLength(250)]
        public string pos_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}

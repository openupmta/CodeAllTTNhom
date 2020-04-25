namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            addresses = new HashSet<address>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cu_id { get; set; }

        [StringLength(50)]
        public string cu_code { get; set; }

        [StringLength(15)]
        public string cu_mobile { get; set; }

        [StringLength(50)]
        public string cu_thumnail { get; set; }

        [StringLength(50)]
        public string cu_email { get; set; }

        [StringLength(50)]
        public string cu_fullname { get; set; }

        public byte? cu_type { get; set; }

        [StringLength(50)]
        public string cu_address { get; set; }

        public DateTime? cu_create_date { get; set; }

        [StringLength(50)]
        public string cu_note { get; set; }

        public DateTime? cu_birthday { get; set; }

        public int? staff_id { get; set; }

        public int? cu_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address> addresses { get; set; }
    }
}

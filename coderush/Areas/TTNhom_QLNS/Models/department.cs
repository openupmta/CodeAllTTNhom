namespace coderush.Areas.TTNhom_QLNS.Models
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
        [Display(Name ="Mã phòng ban ")]
        public int de_id { get; set; }

        [StringLength(50)]
        [Display(Name ="Tên phòng ban")]
        [Required(ErrorMessage ="Tên phòng ban không được để trống")]
        public string de_name { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string de_description { get; set; }
        [Display(Name ="Trạng thái")]
        public byte? de_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}

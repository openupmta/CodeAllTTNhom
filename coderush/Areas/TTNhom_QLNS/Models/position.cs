namespace coderush.Areas.TTNhom_QLNS.Models
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
        [Display(Name ="Mã chức vụ")]
        public int pos_id { get; set; }

        [StringLength(250)]
        [Display(Name ="Tên chức vụ")]
        [Required(ErrorMessage ="Tên chức vụ không được để trống")]
        public string pos_name { get; set; }

        [StringLength(250)]
        [Display(Name ="Mô tả ")]
        public string pos_description { get; set; }
        [Display(Name ="Trạng thái")]
        public byte? pos_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<staff> staffs { get; set; }
    }
}

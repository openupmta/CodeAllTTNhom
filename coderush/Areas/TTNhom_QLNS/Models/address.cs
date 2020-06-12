namespace coderush.Areas.TTNhom_QLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("address")]
    public partial class address
    {
        [Key]
        public int add_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Xã không được để trống")]
        public string add_ward { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Quận/Huyệnkhông được để trống")]
        public string add_district { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tỉnh/Thành phố không được để trống")]
        public string add_province { get; set; }

        [StringLength(150)]
        public string add_detail { get; set; }

        [StringLength(500)]
        public string add_note { get; set; }

        public int? staff_id { get; set; }

        public int? customer_id { get; set; }

        public virtual customer customer { get; set; }

        public virtual staff staff { get; set; }
    }
}

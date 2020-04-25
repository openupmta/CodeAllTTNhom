namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ticket")]
    public partial class ticket
    {
        [Key]
        public int ti_id { get; set; }

        [StringLength(10)]
        public string ti_type { get; set; }

        [StringLength(10)]
        public string ti_title { get; set; }

        [StringLength(10)]
        public string ti_content { get; set; }

        [StringLength(10)]
        public string ti_create_date { get; set; }

        [StringLength(10)]
        public string ti_end_date { get; set; }

        [StringLength(10)]
        public string ti_priority { get; set; }

        [StringLength(10)]
        public string ti_status { get; set; }

        public int? staff_id { get; set; }

        public virtual staff staff { get; set; }
    }
}

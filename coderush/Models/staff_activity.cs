namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class staff_activity
    {
        [Key]
        public int sa_id { get; set; }

        [StringLength(10)]
        public string sa_status { get; set; }

        [StringLength(10)]
        public string sa_log { get; set; }

        [StringLength(10)]
        public string sa_action { get; set; }

        public int? satff_id { get; set; }

        public virtual staff staff { get; set; }
    }
}

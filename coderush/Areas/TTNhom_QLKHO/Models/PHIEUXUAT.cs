namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUAT")]
    public partial class PHIEUXUAT
    {
        public string ID { get; set; }

        public DateTime? NGAYXUAT { get; set; }

        [StringLength(128)]
        public string IDTTPHIEUXUAT { get; set; }

        public virtual TTPHIEUXUAT TTPHIEUXUAT { get; set; }
    }
}

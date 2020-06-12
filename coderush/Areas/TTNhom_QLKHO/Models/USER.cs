namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        public int ID { get; set; }

        public string TENHT { get; set; }

        [StringLength(100)]
        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public int IDROLE { get; set; }

        public virtual USEROLE USEROLE { get; set; }
    }
}

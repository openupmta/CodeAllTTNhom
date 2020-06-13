using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLNS.Models.ModelView
{
    public class staffviewmodel
    {
        
       
        public string sta_code { get; set; }
        public string sta_fullname { get; set; }

        public string sta_email { get; set; }

      
        public string sta_mobile { get; set; }

      
        public int? sta_status { get; set; }
        public int? department_id { get; set; }

        public int? position_id { get; set; }


        public int? group_role_id { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address> addresses { get; set; }

        public virtual department department { get; set; }

        public virtual group_role group_role { get; set; }

        public virtual position position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
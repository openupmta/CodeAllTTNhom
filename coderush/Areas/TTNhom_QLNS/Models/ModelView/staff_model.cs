using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLNS.Models.ModelView
{
    public class staff_model
    {
        [Key]
        public int sta_id { get; set; }

        [Display(Name = "MANV")]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        //[Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [StringLength(50)]
        public string sta_code { get; set; }

        [StringLength(120)]
        public string sta_thumbnai { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ và tên")]
        public string sta_fullname { get; set; }

        [StringLength(45)]
        public string sta_username { get; set; }

        [StringLength(120)]
        public string sta_password { get; set; }

        public byte? sta_sex { get; set; }

        public DateTime? sta_birthday { get; set; }

        [StringLength(50)]
        public string sta_email { get; set; }

        public byte? sta_status { get; set; }

        [Column(TypeName = "ntext")]
        public string sta_aboutme { get; set; }

        [StringLength(11)]
        public string sta_mobile { get; set; }

        [StringLength(20)]
        public string sta_identity_card { get; set; }

        public DateTime? sta_identity_card_date { get; set; }

        public DateTime? sta_created_date { get; set; }

        public int? department_id { get; set; }

        public int? position_id { get; set; }

        public int? sta_leader_id { get; set; }

        public int? group_role_id { get; set; }
    }
}
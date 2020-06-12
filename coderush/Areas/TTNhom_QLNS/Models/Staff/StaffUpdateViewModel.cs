using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLNS.Models.Staff
{
    public class StaffUpdateViewModel
    {
        //Thong tin nhan sự
        public int sta_id { get; set; }
        public string sta_code { get; set; }
        public string sta_thumbnai { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string sta_fullname { get; set; }
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string sta_username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string sta_password { get; set; }
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public byte? sta_sex { get; set; }
        public DateTime? sta_birthday { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        public string sta_email { get; set; }
        public byte? sta_status { get; set; }
        public string sta_aboutme { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string sta_mobile { get; set; }
        public string sta_identity_card { get; set; }
        public DateTime? sta_identity_card_date { get; set; }
        public DateTime? sta_created_date { get; set; }
        public int? department_id { get; set; }
        public int? position_id { get; set; }

        public int? sta_leader_id { get; set; }
        public int? group_role_id { get; set; }
        //Thông tin địa chỉ
        public int? provinceID { get; set; }

        public int? districtID { get; set; }

        public int? wardID { get; set; }

        public string detail { get; set; }
    }
}
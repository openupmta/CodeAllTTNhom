namespace coderush.Areas.TTNhom_QLNS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Net.Http;
    using System.Web.Mvc;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            addresses = new HashSet<address>();
        }

        [Key]
        [Display(Name ="Mã nhân viên")]
        public int sta_id { get; set; }

        [StringLength(50)]
        [Display(Name ="Mã nhân viên")]
        public string sta_code { get; set; }

        [StringLength(120)]
        [Display(Name ="Hình ảnh")]
        public string sta_thumbnai { get; set; }

        [StringLength(45)]
        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage ="Tên nhân viên không được để trống")]
        
        public string sta_fullname { get; set; }

        [StringLength(45)]
        [Display(Name = "Tên đăng nhập")]
        [Remote("ExsitsUserName", "Staffs", ErrorMessage = "Tên đăng nhập đã tồn tại", AdditionalFields = "sta_id")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống ")]
        public string sta_username { get; set; }

        [StringLength(120)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string sta_password { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage ="Giới tính không được để trống")]
        public byte? sta_sex { get; set; }
        [Display(Name = "Ngày sinh ")]
        public DateTime? sta_birthday { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        [Remote("ExsitsEmail", "Staffs", ErrorMessage = "Email đã tồn tại", AdditionalFields = "sta_email")]
        [Required(ErrorMessage ="Email không được để trống")]
        public string sta_email { get; set; }

        [Display(Name = "Trạng thái")]
        public byte? sta_status { get; set; }
            
        [Column(TypeName = "ntext")]
        [Display(Name = "Giới thiệu bản thân")]
        public string sta_aboutme { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string sta_mobile { get; set; }

        [StringLength(20)]
        [Display(Name = "Thẻ căn cước")]
        public string sta_identity_card { get; set; }
        [Display(Name = "Ngày tạo thẻ")]
        public DateTime? sta_identity_card_date { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? sta_created_date { get; set; }

        public int? department_id { get; set; }

        public int? position_id { get; set; }

        public int? sta_leader_id { get; set; }

        public int? group_role_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<address> addresses { get; set; }

        public virtual department department { get; set; }

        public virtual group_role group_role { get; set; }

        public virtual position position { get; set; }
    }
}

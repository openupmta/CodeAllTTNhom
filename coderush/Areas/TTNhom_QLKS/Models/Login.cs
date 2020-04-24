using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLKS.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Mời nhập user")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập user")]
        public string PassWord { set; get; }

        public bool Remember { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLNS.Models.Staff
{
    public class AddressViewModel
    {
        //Thông tin địa chỉ
        public int? provinceID { get; set; }

        public int? districtID { get; set; }

        public int? wardID { get; set; }

        public string detail { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLKS.Models
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}
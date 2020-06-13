using coderush.Areas.TTNhom_QLKS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLKS.Dom
{
    public class KhachHangDom
    {
        QLKSdbContext db = null;
        public KhachHangDom()
        {
            db = new QLKSdbContext();

        }
        public bool Delete(string cmt)
        {
            try
            {
                var KhacHang = db.KhachHangs.Find(cmt);
                db.KhachHangs.Remove(KhacHang);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
using coderush.Areas.TTNhom_QLKS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLKS.Dom
{
    public class PhieuChiDom
    {
        QLKSdbContext db = null;
        public PhieuChiDom()
        {
            db = new QLKSdbContext();
        }
        public bool Delete(int? id)
        {
            //try
            //{
                var PhieuChi = db.PhieuChis.Find(id);
                db.PhieuChis.Remove(PhieuChi);
                db.SaveChanges();
                return true;
            //}
            //catch(Exception)
            //{
            //    return false;
            //}
        }
    }
}
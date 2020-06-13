using coderush.Areas.TTNhom_QLKS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLKS.Dom
{
    public class NhanVienDom
    {
        QLKSdbContext db = null;
        public NhanVienDom()
        {
            db = new QLKSdbContext();

        }
        public bool Delete(byte? id)
        {
            //try
            //{
                var NhanVien = db.NhanViens.Find(id);
                db.NhanViens.Remove(NhanVien);
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
using coderush.Areas.TTNhom_QLKS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace coderush.Areas.TTNhom_QLKS.Dom
{
    public class DichVuChungDom
    {
        QLKSdbContext db = null;
        public DichVuChungDom()
        {
            db = new QLKSdbContext();
        }

        public bool Delete(int? id)
        {
            try
            {
                var dvc = db.DichVuChungs.Find(id);
                db.DichVuChungs.Remove(dvc);
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
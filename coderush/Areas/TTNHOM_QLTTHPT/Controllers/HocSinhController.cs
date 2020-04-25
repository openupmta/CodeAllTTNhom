using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class HocSinhController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/HocSinh
        public ActionResult Index()
        {
            List<HOCSINH> hs = db.HOCSINHs.ToList();
            return View(hs);
        }
    }

    
}
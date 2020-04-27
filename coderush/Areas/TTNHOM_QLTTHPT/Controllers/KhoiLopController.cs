using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;


namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class KhoiLopController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/KhoiLop
        public ActionResult Index()
        {
            List<KHOILOP> res = db.KHOILOPs.ToList();
            return View(res);
        }

    }
}
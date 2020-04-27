using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;


namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class LopController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/Lop
        public ActionResult Index()
        {
            List<LOP> res = db.LOPs.ToList();
            return View(res);
        }
    }
}
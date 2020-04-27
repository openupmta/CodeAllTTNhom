using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class PhanCongController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/PhanCong
        public ActionResult Index()
        {
            List<PHANCONG> res = db.PHANCONGs.ToList();
            return View(res);
        }
    }
}
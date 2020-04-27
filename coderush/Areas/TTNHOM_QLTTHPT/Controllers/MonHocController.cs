using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class MonHocController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/MonHoc
        public ActionResult Index()
        {
            List<MONHOC> res = db.MONHOCs.ToList();
            return View(res);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class GiaoVienController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/GiaoVien
        public ActionResult Index()
        {
            List<GIAOVIEN> res = db.GIAOVIENs.ToList();
            return View(res);
        }
    }
}
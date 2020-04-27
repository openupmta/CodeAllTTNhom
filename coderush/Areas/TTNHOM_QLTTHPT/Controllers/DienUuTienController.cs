using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class DienUuTienController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();
        // GET: TTNHOM_QLTTHPT/DienUuTien
        public ActionResult Index()
        {
            List<DIENUUTIEN> res = db.DIENUUTIENs.ToList();
            return View(res);
        }
    }
}
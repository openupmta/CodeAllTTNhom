using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class DiemChiTietController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();

        // GET: TTNHOM_QLTTHPT/DiemChiTiet
        public ActionResult Index()
        {
            List<DIEMCHITIETMONHOC> res = db.DIEMCHITIETMONHOCs.ToList();
            return View(res);
        }
    }
}
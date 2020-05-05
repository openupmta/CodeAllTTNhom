using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;


namespace coderush.Areas.TTNhom_QLTTHPT.Controllers
{
    public class GiaoVienController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/GiaoVien
        public ActionResult Index()
        {
            List<GIAOVIEN> res = db.GIAOVIENs.ToList();
            return View(res);
        }
    }
}
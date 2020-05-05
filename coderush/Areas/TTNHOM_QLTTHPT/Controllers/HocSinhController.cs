using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLTTHPT.Models;

namespace coderush.Areas.TTNhom_QLTTHPT.Controllers
{
    public class HocSinhController : Controller
    {
        QuanLyTTHPTConText db = new QuanLyTTHPTConText();

        // GET: TTNhom_QLTTHPT/HocSinh
        public ActionResult Index()
        {
            List<HOCSINH> res = db.HOCSINHs.ToList();
            return View(res);
        }
    }
}
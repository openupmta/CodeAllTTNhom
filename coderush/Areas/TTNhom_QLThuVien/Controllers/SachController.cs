using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class SachController : Controller
    {
        DBQLTVContext db = new DBQLTVContext();

        // GET: TTNhom_QLThuVien/Sach
        public ActionResult Index()
        {
            List<Sach> res = db.Saches.ToList();
            return View(res);
        }
    }
}